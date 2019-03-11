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
                        lock (LogsList)
                        {
                            //ReaList<Log> list = LogsList;
                            foreach (var log in LogsList)
                            {
                                //log.Id = new Guid();
                                context.Logs.Add(log);
                            }
                            LogsList.Clear();
                        }

                        if (CarsDict == null)
                        {
                            Thread.Sleep(2000);
                            return;
                        }
                        else
                        {
                            List<string> keysToRemove = new List<string>();
                            lock (CarsDict)
                            {
                                foreach (var CarItem in CarsDict)
                                {
                                    Car car = CarItem.Value;
                                    if (!String.IsNullOrEmpty(car.ArrivalTime))
                                    {
                                        car.Id = new Guid();
                                        keysToRemove.Add(CarItem.Key);
                                        context.Cars.Add(car);
                                        UpdateDataTable(car);
                                    }

                                }
                                foreach (string key in keysToRemove)
                                {
                                    CarsDict.Remove(key);
                                }
                            }
                        }
                        context.SaveChanges();
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
