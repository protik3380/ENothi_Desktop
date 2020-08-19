using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENothi_Desktop.Ui.AlertUi
{
    public partial class Form_Success : Form
    {
        public Form_Success(string message)
        {
            InitializeComponent();
            messageLabel.Text = message;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
            timer1.Stop();
        }

        private void Form_Success_Load(object sender, EventArgs e)
        {
            Top = 20;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 20;
            timer1.Start();
        }
    }
}
