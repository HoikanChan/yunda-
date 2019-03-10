using DXApplication1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DXApplication1
{
    public class TcpServer : IDisposable
    {
        private int _maxClient;                     // 服务器程序允许的最大客户端连接数
        private int _clientCount;                   // 当前连接的客户端数
        private Socket _serverSock;                 // 服务器使用的异步socket
        public List<AsyncSocketState> _clients;     // 客户端会话列表
        private bool disposed = false;


        public bool IsRunning { get; private set; }         // 服务器是否正在运行
        public IPAddress Address { get; private set; }      // 监听的IP地址
        public int Port { get; private set; }               // 监听的端口
        public Encoding Encoding { get; set; }              // 通信使用的编码

        public List<string> _client_msg = new List<string>();     //接收到的客户端数据
        public List<Socket> _client_Socket = new List<Socket>();

        // 构造函数 —— 异步Socket TCP服务器
        public TcpServer(int listenPort)
            : this(IPAddress.Any, listenPort, 1024)
        {
        }
        // 构造函数 —— 异步Socket TCP服务器
        public TcpServer(IPEndPoint localEP, int listenPort)
            : this(localEP.Address, localEP.Port, 1024)
        {
        }
        // 构造函数 —— 异步Socket TCP服务器
        public TcpServer(IPEndPoint localEP)
            : this(localEP.Address, localEP.Port, 1024)
        {
        }

        /// <summary>
        /// 异步Socket TCP服务器
        /// </summary>
        /// <param name="localIPAddress">监听的IP地址</param>
        /// <param name="listenPort">监听的端口</param>
        /// <param name="maxClient">最大客户端数量</param>
        public TcpServer(IPAddress localIPAddress, int listenPort, int maxClient)
        {
            this.Address = localIPAddress;
            this.Port = listenPort;
            this.Encoding = Encoding.Default;

            _maxClient = maxClient;
            _clients = new List<AsyncSocketState>();
            _serverSock = new Socket(localIPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        // 启动服务器
        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                _serverSock.Bind(new IPEndPoint(this.Address, this.Port));
                _serverSock.Listen(1024);
                _serverSock.BeginAccept(new AsyncCallback(HandleAcceptConnected), _serverSock);
            }
        }

        // 启动服务器 —— 服务器所允许挂起连接序列的最大长度
        public void Start(int backlog)
        {
            if (!IsRunning)
            {
                IsRunning = true;
                _serverSock.Bind(new IPEndPoint(this.Address, this.Port));
                _serverSock.Listen(backlog);
                _serverSock.BeginAccept(new AsyncCallback(HandleAcceptConnected), _serverSock);
            }
        }

        // 停止服务器
        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                _serverSock.Close();        //关闭对所有客户端的连接
            }
        }

        // 处理客户端连接
        private void HandleAcceptConnected(IAsyncResult ar)
        {
            if (IsRunning)
            {
                Socket server = (Socket)ar.AsyncState;
                Socket client = server.EndAccept(ar);
                // 检查是否达到最大的允许的客户端数目
                if (_clientCount >= _maxClient)
                {
                    // C - TODO 触发事件
                    RaiseOtherException(null);
                }
                else
                {
                    AsyncSocketState state = new AsyncSocketState(client);
                    lock (_clients)
                    {
                        _clients.Add(state);
                        _clientCount++;
                        RaiseClientConnected(state);    //触发客户端连接事件
                    }
                    Console.WriteLine("客户端接入目前,共" + _clientCount + "个客户端");
                    state.RecvDataBuffer = new byte[client.ReceiveBufferSize];
                    // 开始接受来自该客户端的数据
                    client.BeginReceive(state.RecvDataBuffer, 0, state.RecvDataBuffer.Length,
                        SocketFlags.None, new AsyncCallback(HandleDataReceived), state);
                }
                // 接受下一个请求
                server.BeginAccept(new AsyncCallback(HandleAcceptConnected), ar.AsyncState);
                // 【外部使用】触发连接事件
                //Form1.Sort_Server_client_connect_function(client.RemoteEndPoint.ToString());
            }
        }

        // 处理客户端数据
        private void HandleDataReceived(IAsyncResult ar)
        {
            if (IsRunning)
            {
                AsyncSocketState state = (AsyncSocketState)ar.AsyncState;
                Socket client = state.ClientSocket;
                try
                {
                    // 如果两次开始了异步的接受，所以当客户端退出的时候
                    // 会两次执行EndReceive
                    int bytesRead = client.EndReceive(ar);
                    if (bytesRead == 0)
                    {
                        //C- TODO 触发事件 (关闭客户端)  
                        Close(state);
                        RaiseNetError(state);
                        return;
                    }
                    //TODO 处理已经读取的数据 ps:数据在state的RecvDataBuffer中  

                    //C- TODO 触发数据接收事件  
                    RaiseDataReceived(state, bytesRead);
                }
                catch
                {
                    //C- TODO 异常处理  
                    RaiseNetError(state);
                }
                finally
                {
                    // 继续接收来自客户端的数据
                    try
                    {
                        client.BeginReceive(state.RecvDataBuffer, 0, state.RecvDataBuffer.Length,
                            SocketFlags.None, new AsyncCallback(HandleDataReceived), state);
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="state">接收数据的客户端会话</param>
        /// <param name="data">数据报文</param>
        public void Send(AsyncSocketState state, byte[] data)
        {
            RaisePrepareSend(state);
            Send(state.ClientSocket, data);
        }

        /// <summary>
        /// 异步发送数据至指定的客户端
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="data">报文</param>
        public void Send(Socket client, byte[] data)
        {
            if (!IsRunning)
                throw new InvalidProgramException("This TCP Scoket server has not been started.");

            if (client == null)
                throw new ArgumentNullException("client");

            if (data == null)
                throw new ArgumentNullException("data");
            client.BeginSend(data, 0, data.Length, SocketFlags.None,
                new AsyncCallback(SendDataEnd), client);
        }

        /// <summary>  
        /// 发送数据完成处理函数  
        /// </summary>  
        /// <param name="ar">目标客户端Socket</param>  
        private void SendDataEnd(IAsyncResult ar)
        {
            ((Socket)ar.AsyncState).EndSend(ar);
            RaiseCompletedSend(null);
        }

        // 与客户端连接已建立事件
        public event EventHandler<AsyncSocketEventArgs> ClientConnected;

        // 与客户端连接已断开事件
        public event EventHandler<AsyncSocketEventArgs> ClientDisconnected;

        // 触发客户端连接事件
        private void RaiseClientConnected(AsyncSocketState state)
        {
            if (ClientConnected != null)
            {
                ClientConnected(this, new AsyncSocketEventArgs(state));
            }
        }

        // 触发客户端连接断开事件
        private void RaiseClientDisconnected(Socket client)
        {
            if (ClientDisconnected != null)
            {
                ClientDisconnected(this, new AsyncSocketEventArgs("连接断开"));
            }
        }


        //接收到数据事件
        public event EventHandler<AsyncSocketEventArgs> DataReceived;


         private void RaiseDataReceived(AsyncSocketState state,int bytesRead)
        {
            if (DataReceived != null)
            {
                DataReceived(this, new AsyncSocketEventArgs(state));
            }
            // 把获取到的数据记录到数组中
            string buffer_string = System.Text.Encoding.ASCII.GetString(state.RecvDataBuffer,0,bytesRead);
            Console.WriteLine(buffer_string);
            //Regex rx = new Regex(@"^\[C(\S*?)\](\S*)");
            //Match match = rx.Match(buffer_string);
            //var code = match.Groups[2].Value;
            //var carId = match.Groups[1].Value;
            //using (var context = new AppDbContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //    var car = new Car { CarId = carId, Code = code };
            //    context.Car.Add(car);
            //    context.SaveChanges();
            //}
            //Console.WriteLine("head is {0} and content is {1}", carId, match.Groups[2].Value);
            //var res = await HttpHandler.Request("http://localhost:8000/getCarDestination");
            //Console.WriteLine(res);

            //Send(state.ClientSocket, Encoding.ASCII.GetBytes(carId));

            Form1.UpdateDataTable(buffer_string);
            state.RecvDataBuffer = new byte[1024];
            _client_msg.Add(buffer_string);
            _client_Socket.Add(state.ClientSocket);
        }

        /// 发送数据前的事件  
        public event EventHandler<AsyncSocketEventArgs> PrepareSend;

        // 触发发送数据前的事件  
        private void RaisePrepareSend(AsyncSocketState state)
        {
            if (PrepareSend != null)
            {
                PrepareSend(this, new AsyncSocketEventArgs(state));
            }
        }

        // 数据发送完毕事件 
        public event EventHandler<AsyncSocketEventArgs> CompletedSend;

        // 触发数据发送完毕的事件   
        private void RaiseCompletedSend(AsyncSocketState state)
        {
            if (CompletedSend != null)
            {
                CompletedSend(this, new AsyncSocketEventArgs(state));
            }
        }

        // 网络错误事件  
        public event EventHandler<AsyncSocketEventArgs> NetError;

        // 触发网络错误事件  
        private void RaiseNetError(AsyncSocketState state)
        {
            if (NetError != null)
            {
                NetError(this, new AsyncSocketEventArgs(state));
            }
        }

        // 异常事件  
        public event EventHandler<AsyncSocketEventArgs> OtherException;

        // 触发异常事件  
        private void RaiseOtherException(AsyncSocketState state, string descrip)
        {
            if (OtherException != null)
            {
                OtherException(this, new AsyncSocketEventArgs(descrip, state));
            }
        }

        private void RaiseOtherException(AsyncSocketState state)
        {
            RaiseOtherException(state, "");
        }

        // 关闭一个与客户端之间的会话  
        // 需要关闭的客户端会话对象
        public void Close(AsyncSocketState state)
        {
            if (state != null)
            {
                state.Datagram = null;
                state.RecvDataBuffer = null;

                _clients.Remove(state);
                _clientCount--;
                //TODO 触发关闭事件  
                state.Close();
            }
        }

        // 关闭所有的客户端会话,与所有的客户端连接会断开
        public void CloseAllClient()
        {
            foreach (AsyncSocketState client in _clients)
            {
                Close(client);
            }
            _clientCount = 0;
            _clients.Clear();
        }

        /// <summary>  
        /// Performs application-defined tasks associated with freeing,   
        /// releasing, or resetting unmanaged resources.  
        /// </summary>  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>  
        /// Releases unmanaged and - optionally - managed resources  
        /// </summary>  
        /// <param name="disposing"><c>true</c> to release   
        /// both managed and unmanaged resources; <c>false</c>   
        /// to release only unmanaged resources.</param>  
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    try
                    {
                        Stop();
                        if (_serverSock != null)
                        {
                            _serverSock = null;
                        }
                    }
                    catch (SocketException)
                    {
                        //TODO  
                        RaiseOtherException(null);
                    }
                }
                disposed = true;
            }
        }
    }

    #region  异步 SOCKET TCP 中用来存储客户端状态信息的类
    public class AsyncSocketState
    {
        private byte[] _recvBuffer;             // 接受数据缓冲区
        private string _datagram;               // 客户端发送到服务器的报文，注意：在有些情况下报文可能只是报文的片段而不完整
        public Socket _clientSock;              // 客户端的Socket

        // 接受数据缓冲区
        public byte[] RecvDataBuffer
        {
            get
            {
                return _recvBuffer;
            }
            set
            {
                _recvBuffer = value;
            }
        }

        // 存取会话的报文
        public string Datagram
        {
            get
            {
                return _datagram;
            }
            set
            {
                _datagram = value;
            }
        }

        // 获得与客户端会话关联的Socket对象
        public Socket ClientSocket
        {
            get
            {
                return _clientSock;
            }
        }

        // 构造函数
        public AsyncSocketState(Socket cliSock)
        {
            _clientSock = cliSock;
        }

        // 初始化数据缓冲区
        public void InitBuffer()
        {
            if (_recvBuffer == null && _clientSock != null)
            {
                _recvBuffer = new Byte[_clientSock.ReceiveBufferSize];
            }
        }

        // 关闭会话
        public void Close()
        {
            // 【服务器函数】有客户端断开的时候触发的函数
            //Form1.Sort_Server_client_disconnect_function(_clientSock.RemoteEndPoint.ToString());
            // 关闭数据的接收和发送
            _clientSock.Shutdown(SocketShutdown.Both);
            // 清理资源
            _clientSock.Close();
        }

    }
    #endregion
    public class AsyncSocketEventArgs : EventArgs
    {
        /// <summary>  
        /// 提示信息  
        /// </summary>  
        public string _msg;

        /// <summary>  
        /// 客户端状态封装类  
        /// </summary>  
        public AsyncSocketState _state;

        /// <summary>  
        /// 是否已经处理过了  
        /// </summary>  
        public bool IsHandled { get; set; }

        public AsyncSocketEventArgs(string msg)
        {
            this._msg = msg;
            IsHandled = false;
        }
        public AsyncSocketEventArgs(AsyncSocketState state)
        {
            this._state = state;
            IsHandled = false;
        }
        public AsyncSocketEventArgs(string msg, AsyncSocketState state)
        {
            this._msg = msg;
            this._state = state;
            IsHandled = false;
        }
    }

}
