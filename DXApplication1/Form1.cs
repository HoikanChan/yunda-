using DXApplication1.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;


namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public IPEndPoint serverIpEndpoint { get; private set; }
        public string MainPlcIp = ConfigurationManager.AppSettings["MainPclIp"];

        static public DataTable StateDataTable;
        static public DataTable ResultDataTable;

        //static DataGridView _dataGridView;
        public TcpServer sortServer = null;
        public Dictionary<string, Car> CarsDict;
        public Queue<Car> CarsDbQueue = new Queue<Car>();
        public const int CarTotals = 100;

        public int SortedTotal = 0;
        public int TodaySortedTotal = 0;


        public List<Log> LogsList = new List<Log>();
        public List<Label> Labels;
        public struct IpLabelMapping
        {
            public string ip;
            public Label label;
        }
        public static IpLabelMapping[] IpLabelMappings = new IpLabelMapping[17];
        // 【定义小车货物重量】
        struct CarWeigthData
        {
            public string sorterId;                                     // 分拣机号
            public string weight;                                       // 称重
            public string weight_time;                                  // 称重时间
            public string scan_time;                                    // 扫描时间
        }
        // 【初始化定义小车货物重量】
        CarWeigthData[] CarWeigthDatas = new CarWeigthData[CarTotals];
        public Form1()
        {
            InitializeComponent();
        }
        #region 初始化小车状态列表
        private void InitStateDataTable()
        {
            StateDataTable = new DataTable();//创建DataTable对象
            new List<string> { "小车序号", "单号", "格口", "集包编号", "目的站点","分拣机号","扫描时间" }.ForEach(colName =>
           {
               StateDataTable.Columns.Add(colName, System.Type.GetType("System.String"));

           });
            DataColumn[] keys = new DataColumn[1];

            keys[0] = StateDataTable.Columns[0];
            StateDataTable.PrimaryKey = keys;
            for (int i = 1; i < CarTotals + 1; i++)
            {
                object[] grid_temp_row = new object[3];
                grid_temp_row[0] = i.ToString().PadLeft(4, '0');
                StateDataTable.LoadDataRow(grid_temp_row, LoadOption.OverwriteChanges);
            }
            #region 调整 列宽
            //int width = 0;
            ////对于DataGridView的每一个列都调整
            //for (int i = 0; i < dataGridView.Columns.Count; i++)
            //{
            //    //将每一列都调整为自动适应模式
            //    dataGridView.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
            //    //记录整个DataGridView的宽度
            //    width += dataGridView.Columns[i].Width;
            //}
            ////dataGridView.Columns[0].FillWeight = 40;
            ////dataGridView.Columns[4].FillWeight = 40;

            ////判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            ////则将DataGridView的列自动调整模式设置为显示的列即可，
            ////如果是小于原来设定的宽度，将模式改为填充。
            //if (width > dataGridView.Size.Width)
            //{
            //    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //}
            //else
            //{
            //    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //}
            //冻结某列 从左开始 0，1，2
            //dataGridView.Columns[1].Frozen = true;
            #endregion
            dataGridView.DataSource = StateDataTable;
        }
        #endregion

        #region 初始化集包编号和格口表
        private void InitPackageNoTable()
        {
            using (var dbContext = new AppDbContext())
            {
                var mappings = dbContext.PackageGridMappings.ToList<PackageGridMapping>();
                //DataTable 
                PackageNoGridView.DataSource = mappings;
                gridView2.Columns[0].Caption = "格口ID";
                gridView2.Columns[1].Caption = "目的站点";
                gridView2.Columns[2].Caption = "集包编号";

            }

        }
        #endregion

        #region 初始化小车结果列表
        private void InitResultDataTable()
        {
            ResultDataTable = new DataTable();//创建DataTable对象
            new List<string> { "小车号", "单号", "格口", "集包编号", "目的站点","分拣机号", "扫描时间", "落格时间" }.ForEach(colName =>
            {
                ResultDataTable.Columns.Add(colName, System.Type.GetType("System.String"));

            });
            resultGridView.DataSource = ResultDataTable;
            gridView1.ShowFindPanel();
            gridView2.ShowFindPanel();
            gridView3.ShowFindPanel();

        }
        #endregion

        #region 更新小车状态表
        public void UpdateDataTable(Car car)
        {
            object[] dataRow = new object[7];
            dataRow[0] = car.CarId;
            dataRow[1] = car.OrderNumber;
            //dataRow[2] = car.Weight;
            dataRow[2] = car.CheckNumber;
            dataRow[3] = car.PackageNumber;
            dataRow[4] = car.To;
            dataRow[5] = car.SorterId;
            dataRow[6] = car.SacnTime; 

            Console.WriteLine("写入小车表格：" + car.ToString());
            dataGridView.Invoke(new Action(() =>
            {
                //dataGridView.DataSource = typeof(List<>);
                StateDataTable.BeginLoadData();
                StateDataTable.LoadDataRow(dataRow, LoadOption.OverwriteChanges);
                StateDataTable.EndLoadData();

                //dataGridView.DataSource = StateDataTable;
            }));
        }
        #endregion

        #region 更新结果表
        public void UpdateResultDataTable(Car car)
        {
            DataRow dataRow = ResultDataTable.NewRow();
            dataRow[0] = car.CarId;
            dataRow[1] = car.OrderNumber;
            //dataRow[2] = car.SorterId;
            //dataRow[3] = car.Weight;
            dataRow[2] = car.CheckNumber;
            dataRow[3] = car.PackageNumber;
            dataRow[4] = car.To;
            dataRow[5] = car.SorterId;
            dataRow[6] = car.SacnTime;
            dataRow[7] = car.ArrivalTime;

            Console.WriteLine("写入小车表格：" + car.ToString());
            // 把分拣结果写入到结果表中
            if (resultGridView.InvokeRequired)
            {
                resultGridView.Invoke(new Action(() =>
                {
                    ResultDataTable.BeginLoadData();
                    ResultDataTable.Rows.Add(dataRow);
                    ResultDataTable.EndLoadData();
                }));
            }

        }
        #endregion

        public void UpdateSortedTotalTotal()
        {
            if (sortedTotalLabel.InvokeRequired)
            {
                sortedTotalLabel.Invoke(new Action(() =>
                {
                    SortedTotal++;
                    sortedTotalLabel.Text = sortedTotalLabel.Text.Substring(0, 5) + SortedTotal.ToString();
                }));
                todaySortedTotalLabel.Invoke(new Action(() =>
                {
                    TodaySortedTotal++;
                    todaySortedTotalLabel.Text = todaySortedTotalLabel.Text.Substring(0, 7) + TodaySortedTotal.ToString();
                }));
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Labels = new List<Label>() { MainPlcStateLabel, label1, label2, label3, label4, label5, label7, label6, label8, label9, label11, label10, label2, label3, label4, label5, label7 };

            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
            CarsDict = new Dictionary<string, Car>();

            InitStateDataTable();
            InitPackageNoTable();
            InitResultDataTable();
            InitClientsIpAddress();
            InitCameraState();

            // 【分拣机服务端初始化】
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            serverIpEndpoint = new IPEndPoint(serverIP, 8080);
            sortServer = new TcpServer(serverIpEndpoint);
            sortServer.Start();

            // 【线程初始化】读取服务器接收到的数据的线程
            RecieveDataThread = new Thread(RecieveDataThreadMethod);
            RecieveDataThread.IsBackground = true;
            RecieveDataThread.Start();
            // 【线程初始化】写入数据的线程
            DBRecordThread = new Thread(DBRecordThreadMethod);
            DBRecordThread.IsBackground = true;
            DBRecordThread.Start();
            // 【线程初始化】写入数据的线程
            LogThread = new Thread(LogThreadMethod);
            LogThread.IsBackground = true;
            LogThread.Start();
            AddInfoLog("服务器启动完毕");

        }

        #region 初始化 IP地址和Label对应关系
        private void InitClientsIpAddress()
        {
            IpLabelMappings[0].label = Labels[0];
            IpLabelMappings[0].ip = MainPlcIp;
            for (int i = 1; i <= 16; i++)
            {
                IpLabelMappings[i].label = Labels[i];
                IpLabelMappings[i].ip = "127.0.0.1:40" + i.ToString().PadLeft(2, '0');
            }
        }
        #endregion


        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = new LoginForm().ShowDialog();
            if (result == DialogResult.OK)
            {
                Form factoryForm = new FactoryForm(this);
                factoryForm.Owner = this;
                factoryForm.Show();
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
