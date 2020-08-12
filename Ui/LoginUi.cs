using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENothi_Desktop.Ui
{
    public partial class LoginUi : Form
    {
        public LoginUi()
        {
            InitializeComponent();
        }

        private void LoginUi_Load(object sender, EventArgs e)
        {

        }

        private void footerPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, footerPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.White, 1, ButtonBorderStyle.Solid);// bottom
        }

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, leftPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.White, 1, ButtonBorderStyle.Solid, // top
                Color.FromArgb(220,220,220), 1, ButtonBorderStyle.Solid, // right
                Color.White, 1, ButtonBorderStyle.Solid);// bottom
        }

        private void helpDeskPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, helpDeskPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(94, 18, 152), 2, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(94, 18, 152), 2, ButtonBorderStyle.Solid);// bottom
        }
    }
}
