using DevExpress.XtraEditors;

namespace DXApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PackageNoGridView = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dataGridView = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.resultGridView = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Cam2Percent = new System.Windows.Forms.Label();
            this.Cam1Percent = new System.Windows.Forms.Label();
            this.Cam2Total = new System.Windows.Forms.Label();
            this.Cam2Error = new System.Windows.Forms.Label();
            this.Cam2Correct = new System.Windows.Forms.Label();
            this.Cam1Error = new System.Windows.Forms.Label();
            this.Cam1Correct = new System.Windows.Forms.Label();
            this.Cam1Total = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.MainPlcStateLabel = new System.Windows.Forms.Label();
            this.sortedTotalLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LogsListControl = new DevExpress.XtraEditors.ListBoxControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedComboBoxEdit2 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.todaySortedTotalLabel = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PackageNoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogsListControl)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1166, 537);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PackageNoGridView);
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1158, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "监控报表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PackageNoGridView
            // 
            gridLevelNode2.RelationName = "Level1";
            this.PackageNoGridView.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.PackageNoGridView.Location = new System.Drawing.Point(742, 7);
            this.PackageNoGridView.MainView = this.gridView2;
            this.PackageNoGridView.Name = "PackageNoGridView";
            this.PackageNoGridView.Size = new System.Drawing.Size(400, 480);
            this.PackageNoGridView.TabIndex = 3;
            this.PackageNoGridView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.PackageNoGridView;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // dataGridView
            // 
            this.dataGridView.Location = new System.Drawing.Point(6, 7);
            this.dataGridView.MainView = this.gridView1;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(730, 480);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dataGridView;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.resultGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1158, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "分拣结果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // resultGridView
            // 
            this.resultGridView.Location = new System.Drawing.Point(17, 6);
            this.resultGridView.MainView = this.gridView3;
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.Size = new System.Drawing.Size(1124, 475);
            this.resultGridView.TabIndex = 0;
            this.resultGridView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.resultGridView;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelControl1);
            this.tabPage3.Controls.Add(this.LogsListControl);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1158, 510);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "状态日志";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // Cam2Percent
            // 
            this.Cam2Percent.AutoSize = true;
            this.Cam2Percent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam2Percent.Location = new System.Drawing.Point(235, 240);
            this.Cam2Percent.Name = "Cam2Percent";
            this.Cam2Percent.Size = new System.Drawing.Size(76, 21);
            this.Cam2Percent.TabIndex = 18;
            this.Cam2Percent.Text = "(0.00%）";
            // 
            // Cam1Percent
            // 
            this.Cam1Percent.AutoSize = true;
            this.Cam1Percent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam1Percent.Location = new System.Drawing.Point(235, 157);
            this.Cam1Percent.Name = "Cam1Percent";
            this.Cam1Percent.Size = new System.Drawing.Size(76, 21);
            this.Cam1Percent.TabIndex = 17;
            this.Cam1Percent.Text = "(0.00%）";
            // 
            // Cam2Total
            // 
            this.Cam2Total.AutoSize = true;
            this.Cam2Total.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam2Total.Location = new System.Drawing.Point(189, 242);
            this.Cam2Total.Name = "Cam2Total";
            this.Cam2Total.Size = new System.Drawing.Size(19, 21);
            this.Cam2Total.TabIndex = 16;
            this.Cam2Total.Text = "0";
            // 
            // Cam2Error
            // 
            this.Cam2Error.AutoSize = true;
            this.Cam2Error.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam2Error.Location = new System.Drawing.Point(189, 275);
            this.Cam2Error.Name = "Cam2Error";
            this.Cam2Error.Size = new System.Drawing.Size(19, 21);
            this.Cam2Error.TabIndex = 15;
            this.Cam2Error.Text = "0";
            // 
            // Cam2Correct
            // 
            this.Cam2Correct.AutoSize = true;
            this.Cam2Correct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam2Correct.Location = new System.Drawing.Point(71, 276);
            this.Cam2Correct.Name = "Cam2Correct";
            this.Cam2Correct.Size = new System.Drawing.Size(19, 21);
            this.Cam2Correct.TabIndex = 14;
            this.Cam2Correct.Text = "0";
            // 
            // Cam1Error
            // 
            this.Cam1Error.AutoSize = true;
            this.Cam1Error.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam1Error.Location = new System.Drawing.Point(189, 192);
            this.Cam1Error.Name = "Cam1Error";
            this.Cam1Error.Size = new System.Drawing.Size(19, 21);
            this.Cam1Error.TabIndex = 13;
            this.Cam1Error.Text = "0";
            // 
            // Cam1Correct
            // 
            this.Cam1Correct.AutoSize = true;
            this.Cam1Correct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam1Correct.Location = new System.Drawing.Point(71, 192);
            this.Cam1Correct.Name = "Cam1Correct";
            this.Cam1Correct.Size = new System.Drawing.Size(19, 21);
            this.Cam1Correct.TabIndex = 12;
            this.Cam1Correct.Text = "0";
            // 
            // Cam1Total
            // 
            this.Cam1Total.AutoSize = true;
            this.Cam1Total.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cam1Total.Location = new System.Drawing.Point(189, 157);
            this.Cam1Total.Name = "Cam1Total";
            this.Cam1Total.Size = new System.Drawing.Size(19, 21);
            this.Cam1Total.TabIndex = 11;
            this.Cam1Total.Text = "0";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DXApplication1.Properties.Resources.error;
            this.pictureBox4.Location = new System.Drawing.Point(127, 276);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DXApplication1.Properties.Resources._true;
            this.pictureBox3.Location = new System.Drawing.Point(31, 276);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DXApplication1.Properties.Resources.error;
            this.pictureBox2.Location = new System.Drawing.Point(127, 192);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DXApplication1.Properties.Resources._true;
            this.pictureBox1.Location = new System.Drawing.Point(31, 192);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(27, 239);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(156, 21);
            this.label20.TabIndex = 6;
            this.label20.Text = "扫码器02识别总数：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(27, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(156, 21);
            this.label19.TabIndex = 5;
            this.label19.Text = "扫码器01识别总数：";
            // 
            // MainPlcStateLabel
            // 
            this.MainPlcStateLabel.AutoSize = true;
            this.MainPlcStateLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainPlcStateLabel.Location = new System.Drawing.Point(27, 101);
            this.MainPlcStateLabel.Name = "MainPlcStateLabel";
            this.MainPlcStateLabel.Size = new System.Drawing.Size(151, 21);
            this.MainPlcStateLabel.TabIndex = 4;
            this.MainPlcStateLabel.Text = "主控PLC状态：离线";
            // 
            // sortedTotalLabel
            // 
            this.sortedTotalLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortedTotalLabel.Location = new System.Drawing.Point(27, 57);
            this.sortedTotalLabel.Name = "sortedTotalLabel";
            this.sortedTotalLabel.Size = new System.Drawing.Size(156, 27);
            this.sortedTotalLabel.TabIndex = 0;
            this.sortedTotalLabel.Text = "分拣总数： 0";
            this.sortedTotalLabel.Click += new System.EventHandler(this.label18_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(987, 492);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(156, 21);
            this.label16.TabIndex = 2;
            this.label16.Text = "供包台16状态：离线";
            this.label16.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(987, 457);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 21);
            this.label14.TabIndex = 2;
            this.label14.Text = "供包台14状态：离线";
            this.label14.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(987, 419);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "供包台12状态：离线";
            this.label12.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(799, 492);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(156, 21);
            this.label15.TabIndex = 2;
            this.label15.Text = "供包台15状态：离线";
            this.label15.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(799, 457);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 21);
            this.label13.TabIndex = 2;
            this.label13.Text = "供包台13状态：离线";
            this.label13.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(799, 419);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "供包台11状态：离线";
            this.label11.Visible = false;
            // 
            // LogsListControl
            // 
            this.LogsListControl.Location = new System.Drawing.Point(454, 15);
            this.LogsListControl.Name = "LogsListControl";
            this.LogsListControl.Size = new System.Drawing.Size(689, 474);
            this.LogsListControl.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(987, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "供包台08状态：离线";
            this.label8.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(987, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "供包台04状态：离线";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(987, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "供包台10状态：离线";
            this.label10.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(987, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "供包台06状态：离线";
            this.label6.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(215, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "供包台02状态：离线";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(799, 379);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "供包台09状态：离线";
            this.label9.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(799, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "供包台07状态：离线";
            this.label7.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(799, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "供包台05状态：离线";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(799, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "供包台03状态：离线";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "供包台01状态：离线";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.checkedComboBoxEdit2);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.checkedComboBoxEdit1);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1158, 510);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(389, 281);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 14);
            this.label18.TabIndex = 6;
            this.label18.Text = "2号供包台服务商:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1029, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "工程模式";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedComboBoxEdit2
            // 
            this.checkedComboBoxEdit2.EditValue = "";
            this.checkedComboBoxEdit2.Location = new System.Drawing.Point(516, 278);
            this.checkedComboBoxEdit2.Name = "checkedComboBoxEdit2";
            this.checkedComboBoxEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Snow;
            this.checkedComboBoxEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.checkedComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null)});
            this.checkedComboBoxEdit2.Size = new System.Drawing.Size(168, 20);
            this.checkedComboBoxEdit2.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(389, 204);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 14);
            this.label17.TabIndex = 4;
            this.label17.Text = "1号供包台服务商:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.EditValue = "";
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(516, 201);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Snow;
            this.checkedComboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null)});
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(168, 20);
            this.checkedComboBoxEdit1.TabIndex = 3;
            this.checkedComboBoxEdit1.EditValueChanged += new System.EventHandler(this.checkedComboBoxEdit1_EditValueChanged);
            // 
            // todaySortedTotalLabel
            // 
            this.todaySortedTotalLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todaySortedTotalLabel.Location = new System.Drawing.Point(202, 57);
            this.todaySortedTotalLabel.Name = "todaySortedTotalLabel";
            this.todaySortedTotalLabel.Size = new System.Drawing.Size(169, 27);
            this.todaySortedTotalLabel.TabIndex = 19;
            this.todaySortedTotalLabel.Text = "本日分拣总数： 0";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label19);
            this.panelControl1.Controls.Add(this.todaySortedTotalLabel);
            this.panelControl1.Controls.Add(this.sortedTotalLabel);
            this.panelControl1.Controls.Add(this.MainPlcStateLabel);
            this.panelControl1.Controls.Add(this.Cam2Percent);
            this.panelControl1.Controls.Add(this.label20);
            this.panelControl1.Controls.Add(this.Cam1Percent);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Controls.Add(this.Cam2Total);
            this.panelControl1.Controls.Add(this.pictureBox2);
            this.panelControl1.Controls.Add(this.Cam2Error);
            this.panelControl1.Controls.Add(this.pictureBox3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.Cam2Correct);
            this.panelControl1.Controls.Add(this.pictureBox4);
            this.panelControl1.Controls.Add(this.Cam1Error);
            this.panelControl1.Controls.Add(this.Cam1Total);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.Cam1Correct);
            this.panelControl1.Location = new System.Drawing.Point(19, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(405, 477);
            this.panelControl1.TabIndex = 20;
            // 
            // Form1
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "智能分拣服务器";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PackageNoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogsListControl)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.ListBoxControl LogsListControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraGrid.GridControl dataGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl PackageNoGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl resultGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private CheckedComboBoxEdit checkedComboBoxEdit1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label sortedTotalLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label MainPlcStateLabel;
        private System.Windows.Forms.Label label18;
        private CheckedComboBoxEdit checkedComboBoxEdit2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Cam1Error;
        private System.Windows.Forms.Label Cam1Correct;
        private System.Windows.Forms.Label Cam1Total;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Cam2Percent;
        private System.Windows.Forms.Label Cam1Percent;
        private System.Windows.Forms.Label Cam2Total;
        private System.Windows.Forms.Label Cam2Error;
        private System.Windows.Forms.Label Cam2Correct;
        private System.Windows.Forms.Label todaySortedTotalLabel;
        private PanelControl panelControl1;
    }
}

