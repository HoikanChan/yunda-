using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DXApplication1
{
    partial class Form1
    {
        // 【线程】读取串口接收到的数据的线程
        Thread PortReadingThread = null;
        public SerialPort serialPort;
        bool continueToReadPort = true;
        public void InitPort()
        {
            serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            serialPort.Open();
        }
        // 【线程函数】读取串口接收到的数据的线程
        private void PortReadingThreadMethod()
        {
            while (continueToReadPort)
            {
                string weigtMsg = serialPort.ReadLine();
                Console.WriteLine(weigtMsg);
            }
        }
    }
}
