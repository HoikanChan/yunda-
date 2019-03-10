using DXApplication1.models;
using System;
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
        // 判断PLC第一次传来的数据 [C0002]123456789 0002为车号 12345678为对应条码
        static Regex plcCodeRex = new Regex(@"^\[C");
        // 判断PLC第二次传来的数据 [O0123188] 0123为车号 188代表落格号
        static Regex plcSuccessRex = new Regex(@"^\[O");
        #endregion
        // 【线程】读取服务器接收到的数据的线程
        Thread RecieveDataThread = null;
        // 【线程函数】读取服务器接收到的数据的线程
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
                        string logstring = "[从服务器获取处理数据失败]:" + ex.Message;
                        //log_string.Add(logstring);

                        sortServer._client_msg.Clear();
                        sortServer._client_Socket.Clear();
                    }

                }
                Thread.Sleep(25);
            }
        }
        public async void HandleTcpResponseData(Socket socket, string data)
        {
            if (plcCodeRex.IsMatch(data))
            {
                Regex rx = new Regex(@"^\[C(\S*?)\](\S*)");
                Match match = rx.Match(data);
                var code = match.Groups[2].Value;
                var carId = match.Groups[1].Value;
              
                Console.WriteLine("小车编号 is {0} and 条码 is {1}", carId, match.Groups[2].Value);
                var res = await HttpHandler.Request("http://localhost:8000/getCarDestination?id="+ carId);
                sortServer.Send(socket, Encoding.ASCII.GetBytes(carId + res));
            }
            if (plcSuccessRex.IsMatch(data))
            {
                Regex rx = new Regex(@"^\[O(\d{4})(\d{3})\]$");
                Match match = rx.Match(data);
                var to = match.Groups[2].Value;
                var carId = match.Groups[1].Value;

                //using (var context = new AppDbContext())
                //{
                //    var car = new Car { CarId = carId, To = to };
                //    context.Car.Add(car);
                //    context.SaveChanges();
                //}
                Console.WriteLine("小车编号 is {0} and 落格号 is {1}", carId, match.Groups[2].Value);

            }
        }
    }
}
