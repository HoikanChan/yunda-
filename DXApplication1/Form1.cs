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
        static public DataTable DataTable;
        static DataGridView _dataGridView;
        public TcpServer sortServer = null;
        public Dictionary<string, Car> CarsDict;
        public List<Log> LogsList = new List<Log>();
        public Form1()
        {
            InitializeComponent();  
        }

        private DataTable initDataTable()
        {
            DataTable = new DataTable();//创建DataTable对象
            List<string> colNames = new List<string> { "小车序号", "扫描时间", "小车条形码", "到达时间", "落格口" };
            int i = 0;
            foreach (string colName in colNames)
            {
                DataTable.Columns.Add(colName, System.Type.GetType("System.String"));

                i++;
            }
            
            return DataTable;

        }
        public void UpdateDataTable(Car car)
        {
            DataRow dataRow = Form1.DataTable.NewRow();
            dataRow[0] = car.CarId;
            dataRow[1] = utils.Times.TimeStamp2Time(int.Parse(car.SacnTime));
            dataRow[2] = car.OrderNumber;
            dataRow[3] = utils.Times.TimeStamp2Time(int.Parse(car.ArrivalTime));
            dataRow[4] = car.To;

            DataTable.Rows.Add(dataRow);
            dataGridView.Invoke(new Action(() =>
            {
                dataGridView.DataSource = typeof(List<>);
                dataGridView.DataSource = DataTable;
            }));
        }

            //for (int i = 0; i < 20; i++)
            //{
            //    DataRow dr = dt.NewRow();//创建1行
            //    dr[0] = i;//添加第一列数据
            //    dr[1] = Convert.ToString((i + 80) / 3);//添加第二列数据
            //    DataTable.Rows.Add(dr);//把行加入到；列表中     
            //}
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.Write("here");
            CarsDict = new Dictionary<string, Car>();
            dataGridView.DataSource = initDataTable();
            int width = 0;
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dataGridView.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dataGridView.Columns[i].Width;
            }
            //dataGridView.Columns[0].FillWeight = 40;
            //dataGridView.Columns[4].FillWeight = 40;

            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dataGridView.Size.Width)
            {
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dataGridView.Columns[1].Frozen = true;

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
    }
}
