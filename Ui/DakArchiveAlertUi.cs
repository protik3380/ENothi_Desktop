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
    public partial class DakArchiveAlertUi : Form
    {
        public DakArchiveAlertUi()
        {
            InitializeComponent();
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, topPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.White, 1, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }

        private void DakArchiveAlertUi_Load(object sender, EventArgs e)
        {
            var point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            Top = point.Y + 30;
            Left = (point.X +60)- this.Width;
        }

        private void DakArchiveAlertUi_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DakArchiveAlertUi_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }
    }
}
