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
        static Queue<Log> LogsQueue = new Queue<Log>();
        int log_length = 1000;

        public static void AddInfoLog(string msg)
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
                        bool scroll = false;
                        LogsListControl.Invoke(new Action(() =>
                        {
                            #region 写入到测试窗口
                            int FullIndex = LogsListControl.ItemHeight == 0 ?
                            0 :
                            LogsListControl.Items.Count - (int)(LogsListControl.Height / LogsListControl.ItemHeight);

                            if (LogsListControl.TopIndex == FullIndex)
                            {
                                scroll = true;
                            }
                            LogsListControl.Items.Add(string.Format("[{0}]-{1}", Times.Get_this_time_without_ms(), logstring));
                            if (scroll)
                            {
                                LogsListControl.TopIndex = FullIndex;
                            }
                            if (LogsListControl.Items.Count > log_length)
                            {
                                LogsListControl.Items.Clear();
                            }
                            #endregion
                        }));
                    }
                    catch { }
                }
                Thread.Sleep(25);
            }
        }

     
    }
}
