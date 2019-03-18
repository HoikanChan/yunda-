using DXApplication1.models;
using DXApplication1.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace DXApplication1
{
    partial class Form1
    {
        #region 正则
        // 判断供包台传来的数据 [P01][0002]0.25 01为分拣机号 0002为车号 0.25为重量
        static Regex sortWeightRex = new Regex(@"^\[P");
        // 判断PLC第一次传来的数据 [C0002][123456789]0.25 0002为车号 12345678为对应条码 0.25为重量
        static Regex plcCodeRex = new Regex(@"^\[C(\S*?)\]\[(\S*?)\](\S*)");
        // 判断PLC第二次传来的数据 [O0123]188 0123为车号 188代表落格号
        static Regex plcSuccessRex = new Regex(@"^\[O(\d{4})\](\d*)$");
        #endregion
        // 【线程】读取服务器接收到的数据的线程
        Thread RecieveDataThread = null;

        #region 【线程函数】读取服务器接收到的数据的线程
        private void RecieveDataThreadMethod()
        {
            while (true)
            {
                int msg_count = sortServer._client_msg.Count;
                if (msg_count != 0)
                {

                    //数据处理
                    try
                    {
                        string recv_data = sortServer._client_msg[0];
                        Socket _msg_Socket = sortServer._client_Socket[0];
                        // ??? 处理\0
                        //int buffer_p = recv_data.IndexOf('\0');
                        //recv_data = recv_data.Substring(0, buffer_p);
                        // 把接收到的数据进行分析处理
                        HandleTcpResponseData(_msg_Socket, recv_data);

                        if (sortServer._client_msg.Count <= 1)
                        {
                            sortServer._client_msg.Clear();
                            sortServer._client_Socket.Clear();
                        }
                        else
                        {
                            sortServer._client_msg.RemoveAt(0);
                            sortServer._client_Socket.RemoveAt(0);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        AddErrorLog("[从服务器获取处理数据失败]:" + ex.Message);
                        sortServer._client_msg.Clear();
                        sortServer._client_Socket.Clear();
                    }

                }
                Thread.Sleep(25);
            }
        }
        #endregion

        #region 处理Tcp传来的数据
        public void HandleTcpResponseData(Socket socket, string data)
        {
            AddInfoLog("收到数据：" + data);
            if (sortWeightRex.IsMatch(data))
            {
                HandleWeight(socket, data);
            }
            else if (plcCodeRex.IsMatch(data))
            {
                HandlePlcCode(socket, data);
            }
            else if (plcSuccessRex.IsMatch(data))
            {
                HandlePlcSuccess(socket, data);
            }
            else
            {
                AddErrorLog("收到无效数据：" + data);
            }
        }

        #endregion

        #region 处理供包台传来的称重信息
        private void HandleWeight(Socket socket, string data)
        {
            try
            {
                Regex rx = new Regex(@"^\[P(\S*?)\]\[(\S*?)\](\S*?)$");
                Match match = rx.Match(data);
                // 分拣机号
                var sorterId = match.Groups[1].Value;
                // 车号
                var carId = match.Groups[2].Value;
                // 重量
                var weight = match.Groups[3].Value;
                int index = int.Parse(carId);
                if (weight == "0.00")
                {
                    weight = "0.10";
                }

                CarWeigthDatas[index].weight = weight;
                CarWeigthDatas[index].sorterId = sorterId;
                CarWeigthDatas[index].weight_time = Times.GetTimeStamp();

                AddInfoLog("[数据-P-接收成功]{" + data + "}");
            }
            catch (System.Exception ex)
            {
                AddErrorLog("[数据-P-处理失败]{" + data + "}:" + ex.Message);
                return;
            }
        }
        #endregion

        #region 处理PLC传来的单号
        private async void HandlePlcCode(Socket socket, string data)
        {
            Regex rx = plcCodeRex;
            Match match = rx.Match(data);
            var carId = match.Groups[1].Value;
            var orderNumber = match.Groups[2].Value;

            var weight = match.Groups[3].Value;
            var carIndex = int.Parse(carId);
            var packageNumber = await Request(orderNumber);
            using (var dbContext = new AppDbContext())
            {
                try
                {
                    var mapping = dbContext.PackageGridMappings.Single(i => i.PackageNumber == packageNumber);
                    if (mapping == null)
                    {
                        AddErrorLog("[数据-C-处理失败]{" + data + "}:数据库无对应的格口");
                        return;
                    }
                    var checkId = mapping.CheckId;
                    sortServer.Send(socket, Encoding.ASCII.GetBytes(carId + checkId));
                    AddInfoLog(string.Format("成功回传数据到供包台，小车号为{0}，格口号为{1}", carId, checkId));
                    if (string.IsNullOrEmpty(weight))
                    {
                        Console.WriteLine("未记录重量,小车号为：" + carId);
                    }
                    CarWeigthDatas[carIndex].scan_time = Times.GetTimeStamp();

                    UpdateDataTable(new Car()
                    {
                        CarId = carId,
                        OrderNumber = orderNumber,
                        SacnTime = utils.Times.GetTimeStamp(),
                        PackageNumber = packageNumber,
                        Weight = weight,
                        To = mapping.GoalNumber,
                        CheckNumber = checkId
                    });
                    AddInfoLog("[数据-C-处理成功，记录入表]{" + data + "}");

                }
                catch (Exception e)
                {
                    AddErrorLog("[数据-C-处理失败]{" + data + "}:" + e.Message);
                }
            }
        }
        #endregion

        #region 处理PLC成功落格回传信息
        private void HandlePlcSuccess(Socket socket, string data)
        {
            Regex rx = plcSuccessRex;
            Match match = rx.Match(data);
            var to = match.Groups[2].Value;
            var carId = match.Groups[1].Value;
            int carIndex = Convert.ToInt32(carId);
            var row = StateDataTable.Rows[carIndex - 1];
            Car result = new Car()
            {
                CarId = carId,
                SorterId = CarWeigthDatas[carIndex].sorterId,
                OrderNumber = row[1].ToString(),
                Weight = row[2].ToString(),
                CheckNumber = row[3].ToString(),
                PackageNumber = row[4].ToString(),
                To = row[5].ToString(),
                SacnTime = CarWeigthDatas[carIndex].scan_time,
                WeightTime = CarWeigthDatas[carIndex].weight_time,
                ArrivalTime = Times.GetTimeStamp()
            };
            CarsDbQueue.Enqueue(result);
            UpdateResultDataTable(result);
            UpdateSortedTotalTotal();
            AddInfoLog("[数据-O-处理成功]{" + data + "}");
            Console.WriteLine("小车编号 : {0} and 落格号 : {1}", carId, match.Groups[2].Value);
        }
        #endregion

        internal static void ServerConnected(string ipAddress)
        {
            var mapping = IpLabelMappings.SingleOrDefault(i => i.ip == ipAddress);
            var index = Array.FindIndex(IpLabelMappings, i => i.ip == ipAddress);

            AddInfoLog(string.Format("与供包台{1}成功连接，ip为{0}", ipAddress, (index + 1).ToString().PadLeft(2)));
            if (mapping.label != null)
            {
                mapping.label.Invoke(new Action(() =>
                {
                    mapping.label.Text = mapping.label.Text.Replace('离', '在');
                }));
            }
        }
        internal static void ServerDisConnected(string ipAddress)
        {
            var mapping = IpLabelMappings.SingleOrDefault(i => i.ip == ipAddress);
            var index = Array.FindIndex(IpLabelMappings, i => i.ip == ipAddress);

            AddInfoLog(string.Format("与供包台{1}断开连接，ip为{0}", ipAddress, (index + 1).ToString().PadLeft(2)));

            if (mapping.label != null)
            {
                mapping.label.Invoke(new Action(() =>
                {
                    mapping.label.Text = mapping.label.Text.Replace('在', '离');
                }));
            }
        }
    }
}
