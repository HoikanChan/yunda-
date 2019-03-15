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

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public IPEndPoint serverIpEndpoint { get; private set; }
        static public DataTable StateDataTable;
        static public DataTable ResultDataTable;

        //static DataGridView _dataGridView;
        public TcpServer sortServer = null;
        public Dictionary<string, Car> CarsDict;
        public Queue<Car> CarsDbQueue = new Queue<Car>();
        public const int CarTotals = 100;

        public List<Log> LogsList = new List<Log>();

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
            new List<string> { "小车序号", "单号", "称重", "格口", "集包编号" , "目的站点" }.ForEach(colName =>
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
                PackageNoGridView.DataSource = mappings;
                PackageNoGridView.Columns[0].HeaderText = "格口ID";
                PackageNoGridView.Columns[1].HeaderText = "目的站点";
                PackageNoGridView.Columns[2].HeaderText = "集包编号";

            }

        }
        #endregion

        #region 初始化小车结果列表
        private void InitResultDataTable()
        {
            ResultDataTable = new DataTable();//创建DataTable对象
            new List<string> { "小车号", "单号", "称重台号","重量", "格口", "集包编号", "目的站点" , "扫描时间" , "称重时间" ,"落格时间"}.ForEach(colName =>
            {
                ResultDataTable.Columns.Add(colName, System.Type.GetType("System.String"));

            });
            resultGridView.DataSource = ResultDataTable;
        }
        #endregion

        #region 更新小车状态表
        public void UpdateDataTable(Car car)
        {
            object[] dataRow = new object[6];
            dataRow[0] = car.CarId;
            dataRow[1] = car.OrderNumber;
            dataRow[2] = car.Weight;
            dataRow[3] = car.CheckNumber;
            dataRow[4] = car.PackageNumber;
            dataRow[5] = car.To;
            Console.WriteLine("写入小车表格：" + car.ToString());
            StateDataTable.LoadDataRow(dataRow, LoadOption.OverwriteChanges);
            dataGridView.Invoke(new Action(() =>
            {
                dataGridView.DataSource = typeof(List<>);
                dataGridView.DataSource = StateDataTable;
            }));
        }
        #endregion

        #region 更新结果表
        public void UpdateResultDataTable(Car car)
        {
            DataRow dataRow = ResultDataTable.NewRow();
            dataRow[0] = car.CarId;
            dataRow[1] = car.OrderNumber;
            dataRow[2] = car.SorterId;
            dataRow[3] = car.Weight;
            dataRow[4] = car.CheckNumber;
            dataRow[5] = car.PackageNumber;
            dataRow[6] = car.To;
            dataRow[7] = car.SacnTime;
            dataRow[8] = car.WeightTime;
            dataRow[9] = car.ArrivalTime;

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
        //for (int i = 0; i < 20; i++)
        //{
        //    DataRow dr = dt.NewRow();//创建1行
        //    dr[0] = i;//添加第一列数据
        //    dr[1] = Convert.ToString((i + 80) / 3);//添加第二列数据
        //    DataTable.Rows.Add(dr);//把行加入到；列表中     
        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
            Console.Write("here");
            CarsDict = new Dictionary<string, Car>();
            InitStateDataTable();
            InitPackageNoTable();
            InitResultDataTable();
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
            // 【线程初始化】读取串口的线程
            InitPort();
            PortReadingThread = new Thread(PortReadingThreadMethod);
            PortReadingThread.IsBackground = true;
            PortReadingThread.Start();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "D:" + "\\KKHMD.xls";
            ExportExcels(a, dataGridView);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        #region 处理Excel
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="myDGV">控件DataGridView</param>
        private void ExportExcels(string fileName, DataGridView myDGV)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
            //写入标题
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
