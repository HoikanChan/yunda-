using DXApplication1.models;
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
        // 【线程】数据库写入数据的线程
        Thread DBRecordThread = null;
        // 【线程函数】数据库写入数据的线程
        private void DBRecordThreadMethod()
        {
            while (true)
            {
                using (var context = new AppDbContext())
                {
                    try
                    {
                        Car[] cars = new Car[0];
                        Log[] logs = new Log[0]; ;
                        if (CarsDbQueue.Count != 0)
                        {
                            lock (CarsDbQueue)
                            {
                                cars = CarsDbQueue.ToArray();
                                CarsDbQueue.Clear();
                            }
                            Array.ForEach(cars, Car => context.Cars.Add(Car));
                        }
                        //if (LogsQueue.Count != 0)
                        //{
                        //    lock (LogsQueue)
                        //    {
                        //        logs = LogsQueue.ToArray();
                        //        LogsQueue.Clear();
                        //    }
                        //    Array.ForEach(logs, Log => context.Logs.Add(Log));
                        //}
                            if (cars.Length != 0 || logs.Length != 0)
                        {
                            int result = context.SaveChanges();
                            Console.WriteLine("已插入{0}条数据", result);
                        }
                    }
                    catch(Exception e)
                    {
                        AddErrorLog("【写入数据库错误】" + e.Message);
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
