using DXApplication1.models;
using DXApplication1.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace DXApplication1
{
    partial class Form1
    {
        #region 正则
        // 判断供包台传来的数据 [P01][0002]0.25 01为分拣机号 0002为车号 0.25为重量
        static Regex sortWeightRex = new Regex(@"^\[P");
        // 判断PLC第一次传来的数据 [C0002]123456789 0002为车号 1为相机号 2345678为对应条码
        static Regex plcCodeRex = new Regex(@"^\[C(\d*?)\](\d)(\d*?)$");
        // 判断是否条码未扫到，为noread
        static Regex noreadRex = new Regex(@"^\[C(\d*?)\](\d)no\S*$");
        // 判断PLC第二次传来的数据 [O0123]188 0123为车号 188代表落格号
        static Regex plcSuccessRex = new Regex(@"^\[O(\d{4})\](\d*)$");

        #endregion
        // 【线程】读取服务器接收到的数据的线程
        Thread RecieveDataThread = null;
        List<CameraState> cameraStates;
        public void InitCameraState()
        {
            cameraStates = new List<CameraState> {
                new CameraState { CameraNum = 1 ,TotalLabel= Cam1Total ,ErrorLabel = Cam1Error , CorrectLabel = Cam1Correct, PercentLabel = Cam1Percent},
                new CameraState { CameraNum = 2 ,TotalLabel= Cam2Total ,ErrorLabel = Cam2Error , CorrectLabel = Cam2Correct, PercentLabel = Cam2Percent}
            };
        }

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
            if (noreadRex.IsMatch(data))
            {
                HandleNoread(socket, data);
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
        private void HandleNoread(Socket socket, string data)
        {
            try
            {
                Regex rx = noreadRex;
                Match match = rx.Match(data);
                var carId = match.Groups[1].Value;
                var cameraNumber = match.Groups[2].Value;
                if (cameraNumber != "1" && cameraNumber != "2")
                {
                    AddErrorLog(string.Format("[数据-noread]{{2}}异常，相机号不存在", cameraNumber, carId, data));
                    return;
                }
                CameraState camera = cameraStates.First(cam => cam.CameraNum == int.Parse(cameraNumber));
                camera.CameraError++;
                camera.CameraScaned++;
                AddErrorLog(string.Format("[数据-noread]{{2}}相机{0}未扫描条码，小车号为{1}", cameraNumber, carId, data));
            }
            catch (System.Exception ex)
            {
                AddErrorLog("[数据-noread-处理失败]{" + data + "}:" + ex.Message);
                return;
            }
        }
        #endregion

        #region 处理PLC传来的单号
        //收到小车号码 + 相机号 + 订单号码 
        //  => 按订单号码http查包裹号
        //  => 按包裹号，在localDB查询对应格口
        //  => 格口号多个时，查询格口是否已满，发送到第一个空格口中，全满时默认放入第一个格口

        private async void HandlePlcCode(Socket socket, string data)
        {
            Regex rx = plcCodeRex;
            Match match = rx.Match(data);
            var carId = match.Groups[1].Value;
            var cameraNumber = match.Groups[2].Value;
            var orderNumber = match.Groups[3].Value;
            //var weight = match.Groups[4].Value;
            var carIndex = int.Parse(carId);

            CameraState camera = cameraStates.First(cam => cam.CameraNum == int.Parse(cameraNumber));
            camera.CameraScaned++;

            //  => 按订单号码http查包裹号
            var packageNumber = await Request(orderNumber);
            //var packageNumber = "405476679929";

            //  => 按包裹号，在localDB查询对应格口
            using (var dbContext = new AppDbContext())
            {
                try
                {
                    var mappings = dbContext.PackageGridMappings.Where(i => i.PackageNumber == packageNumber).ToList();
                    PackageGridMapping resultMapping = null;

                    if (mappings.Count == 0)
                    {
                        AddErrorLog("[数据-C-处理失败]{" + data + "}:数据库无对应的格口");
                        return;
                    }
                    else if (mappings.Count == 1)
                    {
                        resultMapping = mappings[0];
                    }
                    //  => 格口号多个时，查询格口是否已满，发送到第一个空格口中，全满时默认放入第一个格口
                    else if (mappings.Count > 1)
                    {
                        List<GridState> GridList = SqliteManager.ReadSqlite();
                        foreach (var mapping in mappings)
                        {

                            GridState gridState = GridList.Find(grid => grid.Grid == int.Parse(mapping.CheckId));
                            if (gridState.Status == 0)
                            {
                                resultMapping = mapping;
                                break;
                            }
                            else
                            {
                                AddInfoLog(string.Format("格口号【{0}】已满，转移到下一格口", mapping.CheckId));
                            }
                        }
                        if (resultMapping == null)
                        {
                            resultMapping = mappings[0];
                            AddErrorLog("包裹对应格口都已满，转移到第一个对应格口");
                        }

                    }
                    SendToMainPlc(carId, resultMapping.CheckId);
                    //CarWeigthDatas[carIndex].scan_time = Times.GetTimeStamp();

                    UpdateDataTable(new Car()
                    {
                        CarId = carId,
                        OrderNumber = orderNumber,
                        SacnTime = utils.Times.GetTimeStamp(),
                        PackageNumber = packageNumber,
                        //Weight = weight,
                        To = resultMapping.GoalNumber,
                        CheckNumber = resultMapping.CheckId
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

        #region 处理接到Tcp连接时Label的变化
        internal static void ServerConnected(string ipAddress)
        {
            var mapping = IpLabelMappings.SingleOrDefault(i => i.ip == ipAddress);
            var index = Array.FindIndex(IpLabelMappings, i => i.ip == ipAddress);

            if (mapping.label != null)
            {
                if (index == 0)
                {
                    AddInfoLog(string.Format("与主控PLC成功连接，ip为{0}", ipAddress));
                }
                else
                {
                    AddInfoLog(string.Format("与供包台{1}成功连接，ip为{0}", ipAddress, index.ToString().PadLeft(2)));
                }
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

            if (mapping.label != null)
            {
                if (index == 0)
                {
                    AddInfoLog(string.Format("与主控PLC断开连接，ip为{0}", ipAddress));
                }
                else
                {
                    AddInfoLog(string.Format("与供包台{1}断开连接，ip为{0}", ipAddress, index.ToString().PadLeft(2)));
                }
                mapping.label.Invoke(new Action(() =>
                {
                    mapping.label.Text = mapping.label.Text.Replace('在', '离');
                }));
            }
        }
        #endregion

        #region 发送到主控PLC 格式 101-> 50 01, 100 -> 50 00
        public void SendToMainPlc(string carNum, string grid)
        {
            if (sortServer._clients.Count > 0)
            {
                var Client = sortServer._clients.SingleOrDefault(item => item.ClientSocket.RemoteEndPoint.ToString() == MainPlcIp);
                if (Client != null)
                {
                    string data = carNum + "00";
                    byte[] byteArray = Encoding.ASCII.GetBytes(data);
                    int gridNum = int.Parse(grid);
                    if (gridNum % 2 == 0)
                    {
                        byteArray[4] = (byte)Convert.ToInt32((gridNum / 2).ToString().PadLeft(2, '0'));
                        byteArray[5] = (byte)Convert.ToInt32("00");
                    }
                    else
                    {
                        byteArray[4] = (byte)Convert.ToInt32((gridNum / 2 + 1).ToString().PadLeft(2, '0'));
                        byteArray[5] = (byte)Convert.ToInt32("01");
                    }
                    sortServer.Send(Client._clientSock, byteArray);
                    AddInfoLog(string.Format("成功回传数据到供包台，小车号为{0}，格口号为{1}", carNum, gridNum));
                }
            }

        }
        #endregion

    }
    class CameraState
    {
        public Label TotalLabel { get; set; }
        public Label ErrorLabel { get; set; }
        public Label CorrectLabel { get; set; }
        public Label PercentLabel { get; set; }
        public int CameraNum { get; set; }
        public double CameraScaned { get; set; }
        public double CameraError { get; set; }
        public string getCorrectPercent()
        {
            if(this.CameraScaned == 0)
            {
                return String.Format("{0:F}", 0);
            }
            double percent = (1.0f - CameraError / CameraScaned) * 100.0f;
            string result = String.Format("{0:F}", percent);
            //double result = (CameraScaned - CameraError) / CameraScaned;
            //result = Math.Round(result, 2)*100;
            return result.ToString();
        }
    }
}
