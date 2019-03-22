using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DXApplication1
{
    public partial class FactoryForm : Form
    {
        private Form1 ParentForm;
        System.Threading.Timer timer;
        public FactoryForm(Form1 form)
        {
            this.ParentForm = form;
            //this.Owner.
            InitializeComponent();
            FixedProgressBarControl.Properties.Step = 1;
            FixedProgressBarControl.Properties.PercentView = true;
            FixedProgressBarControl.Properties.Maximum = Form1.CarTotals;
            FixedProgressBarControl.Properties.Minimum = 0;
            RandomProgressBarControl.Properties.Step = 1;
            RandomProgressBarControl.Properties.PercentView = true;
            RandomProgressBarControl.Properties.Maximum = Form1.CarTotals;
            RandomProgressBarControl.Properties.Minimum = 0;
        }

        private void FactoryForm_Load(object sender, EventArgs e)
        {
            FixedTestRateText.Text = "50";
            RandomTestRateText.Text = "50";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void FixedTestStartBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FixedTestGridText.Text) && !string.IsNullOrEmpty(FixedTestRateText.Text))
            {
                FixedProgressBarControl.Visible = true;
                for (int i = 1; i <= Form1.CarTotals; i++)
                {
                    ParentForm.SendToMainPlc(i.ToString().PadLeft(4, '0'), FixedTestGridText.Text);
                    FixedProgressBarControl.PerformStep();
                    FixedProgressBarControl.Update();
                    Thread.Sleep(int.Parse(FixedTestRateText.Text));
                }
            }
        }
        void ResetProgressBar()
        {
            FixedProgressBarControl.Decrement(Form1.CarTotals);
            FixedProgressBarControl.Visible = false;
        }
        private void FixedTestGridText_EditValueChanged(object sender, EventArgs e)
        {
            ResetProgressBar();
        }

        private void FixedTestRateText_EditValueChanged(object sender, EventArgs e)
        {
            ResetProgressBar();
        }

        private void RamdomTestStartBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RandomMinText.Text) && !string.IsNullOrEmpty(RandomTestRateText.Text) && !string.IsNullOrEmpty(RandomMaxText.Text))
            {
                RandomProgressBarControl.Visible = true;
                int max = int.Parse(RandomMaxText.Text) + 1;
                int min = int.Parse(RandomMinText.Text);

                for (int i = 1; i <= Form1.CarTotals; i++)
                {

                    string randomGridNo = new Random().Next(min, max).ToString();
                    ParentForm.SendToMainPlc(i.ToString().PadLeft(4, '0'), randomGridNo);
                    RandomProgressBarControl.PerformStep();
                    RandomProgressBarControl.Update();
                    Thread.Sleep(int.Parse(RandomTestRateText.Text));
                }
            }
        }
    }
}
