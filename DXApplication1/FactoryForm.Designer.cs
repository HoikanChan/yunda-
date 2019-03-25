namespace DXApplication1
{
    partial class FactoryForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.FixedProgressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.label6 = new System.Windows.Forms.Label();
            this.FixedTestStartBtn = new DevExpress.XtraEditors.SimpleButton();
            this.FixedTestRateText = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FixedTestGridText = new DevExpress.XtraEditors.TextEdit();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RandomProgressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.label7 = new System.Windows.Forms.Label();
            this.RandomMaxText = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.RandomTestStartBtn = new DevExpress.XtraEditors.SimpleButton();
            this.RandomTestRateText = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RandomMinText = new DevExpress.XtraEditors.TextEdit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FixedProgressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FixedTestRateText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FixedTestGridText.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RandomProgressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMaxText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomTestRateText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMinText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 4);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 358);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.FixedProgressBarControl);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.FixedTestStartBtn);
            this.tabPage1.Controls.Add(this.FixedTestRateText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.FixedTestGridText);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "定格测试";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FixedProgressBarControl
            // 
            this.FixedProgressBarControl.Location = new System.Drawing.Point(0, 6);
            this.FixedProgressBarControl.Name = "FixedProgressBarControl";
            this.FixedProgressBarControl.Size = new System.Drawing.Size(597, 18);
            this.FixedProgressBarControl.TabIndex = 6;
            this.FixedProgressBarControl.Visible = false;
            this.FixedProgressBarControl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.FixedProgressBarControl_ControlAdded);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "ms";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // FixedTestStartBtn
            // 
            this.FixedTestStartBtn.Location = new System.Drawing.Point(158, 244);
            this.FixedTestStartBtn.Name = "FixedTestStartBtn";
            this.FixedTestStartBtn.Size = new System.Drawing.Size(266, 32);
            this.FixedTestStartBtn.TabIndex = 4;
            this.FixedTestStartBtn.Text = "开始发送";
            this.FixedTestStartBtn.Click += new System.EventHandler(this.FixedTestStartBtn_Click);
            // 
            // FixedTestRateText
            // 
            this.FixedTestRateText.Location = new System.Drawing.Point(247, 149);
            this.FixedTestRateText.Name = "FixedTestRateText";
            this.FixedTestRateText.Size = new System.Drawing.Size(177, 20);
            this.FixedTestRateText.TabIndex = 3;
            this.FixedTestRateText.EditValueChanged += new System.EventHandler(this.FixedTestRateText_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "发送频率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "格口号：";
            // 
            // FixedTestGridText
            // 
            this.FixedTestGridText.Location = new System.Drawing.Point(247, 94);
            this.FixedTestGridText.Name = "FixedTestGridText";
            this.FixedTestGridText.Size = new System.Drawing.Size(177, 20);
            this.FixedTestGridText.TabIndex = 0;
            this.FixedTestGridText.EditValueChanged += new System.EventHandler(this.FixedTestGridText_EditValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RandomProgressBarControl);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.RandomMaxText);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.RandomTestStartBtn);
            this.tabPage2.Controls.Add(this.RandomTestRateText);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.RandomMinText);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "随机测试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RandomProgressBarControl
            // 
            this.RandomProgressBarControl.Location = new System.Drawing.Point(-3, 6);
            this.RandomProgressBarControl.Name = "RandomProgressBarControl";
            this.RandomProgressBarControl.Size = new System.Drawing.Size(603, 18);
            this.RandomProgressBarControl.TabIndex = 13;
            this.RandomProgressBarControl.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(431, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "ms";
            // 
            // RandomMaxText
            // 
            this.RandomMaxText.Location = new System.Drawing.Point(353, 95);
            this.RandomMaxText.Name = "RandomMaxText";
            this.RandomMaxText.Size = new System.Drawing.Size(72, 20);
            this.RandomMaxText.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "~";
            // 
            // RandomTestStartBtn
            // 
            this.RandomTestStartBtn.Location = new System.Drawing.Point(159, 245);
            this.RandomTestStartBtn.Name = "RandomTestStartBtn";
            this.RandomTestStartBtn.Size = new System.Drawing.Size(266, 32);
            this.RandomTestStartBtn.TabIndex = 9;
            this.RandomTestStartBtn.Text = "开始发送";
            this.RandomTestStartBtn.Click += new System.EventHandler(this.RamdomTestStartBtn_Click);
            // 
            // RandomTestRateText
            // 
            this.RandomTestRateText.Location = new System.Drawing.Point(248, 149);
            this.RandomTestRateText.Name = "RandomTestRateText";
            this.RandomTestRateText.Size = new System.Drawing.Size(177, 20);
            this.RandomTestRateText.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "发送频率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "格口号：";
            // 
            // RandomMinText
            // 
            this.RandomMinText.Location = new System.Drawing.Point(248, 94);
            this.RandomMinText.Name = "RandomMinText";
            this.RandomMinText.Size = new System.Drawing.Size(74, 20);
            this.RandomMinText.TabIndex = 5;
            // 
            // FactoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 376);
            this.Controls.Add(this.tabControl1);
            this.Name = "FactoryForm";
            this.Text = "FactoryForm";
            this.Load += new System.EventHandler(this.FactoryForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FixedProgressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FixedTestRateText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FixedTestGridText.Properties)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RandomProgressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMaxText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomTestRateText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMinText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.SimpleButton FixedTestStartBtn;
        private DevExpress.XtraEditors.TextEdit FixedTestRateText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit FixedTestGridText;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.TextEdit RandomMaxText;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton RandomTestStartBtn;
        private DevExpress.XtraEditors.TextEdit RandomTestRateText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit RandomMinText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ProgressBarControl FixedProgressBarControl;
        private DevExpress.XtraEditors.ProgressBarControl RandomProgressBarControl;
    }
}