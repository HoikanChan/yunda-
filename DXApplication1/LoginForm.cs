using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(PswTextBox.Text == "yunda123")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                ErrorLabel.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
