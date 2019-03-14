using DXApplication1.models;
using DXApplication1.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DXApplication1
{
    partial class Form1
    {
        Queue<Log> LogsQueue = new Queue<Log>();
        public void AddInfoLog(string msg)
        {
            LogsQueue.Enqueue(new Log()
            {
                Type = LogType.success,
                Content = msg,
                Created = utils.Times.GetTime()
            });
        }
        public void AddErrorLog(string msg)
        {
            LogsQueue.Enqueue(new Log()
            {
                Type = LogType.error,
                Content = msg,
                Created = utils.Times.GetTime()
            });
        }
        // 【线程】数据库写入数据的线程
        Thread LogThread = null;
        // 【线程函数】数据库写入数据的线程
        private void LogThreadMethod()
        {
            Thread.Sleep(3000);
            while (true)
            {
                if (LogsQueue.Count != 0)
                {
                    try
                    {
                        string logstring = LogsQueue.Dequeue().ToString();
                        Logger.WriteLog_info(typeof(Form1), logstring);
                    }
                    catch { }
                }
                Thread.Sleep(25);
            }
        }
    }
}
