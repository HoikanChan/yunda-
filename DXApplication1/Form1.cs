using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public IPEndPoint serverIpEndpoint { get; private set; }
        static public DataTable DataTable;
        static DataGridView _dataGridView;
        TcpServer sortServer = null;

        public Form1()
        {
            

            InitializeComponent();


        }

        private DataTable initDataTable()
        {
            DataTable = new DataTable();//创建DataTable对象
            List<string> colNames = new List<string> { "序号", "时间", "小车", "条形码", "重量" };
            foreach(string colName in colNames)
            {
                DataTable.Columns.Add(colName, System.Type.GetType("System.String"));
            }
            
            return DataTable;

        }
        static public void UpdateDataTable(string msg)
        {
            DataRow dataRow = Form1.DataTable.NewRow();
            dataRow[0] = msg;
            DataTable.Rows.Add(dataRow);
            _dataGridView.Invoke(new Action(() =>
            {
                _dataGridView.DataSource = DataTable;
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
            _dataGridView = dataGridView;
            dataGridView.DataSource = initDataTable();

            // 【分拣机服务端初始化】
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            serverIpEndpoint = new IPEndPoint(serverIP, 8080);
            sortServer = new TcpServer(serverIpEndpoint);
            sortServer.Start();
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
