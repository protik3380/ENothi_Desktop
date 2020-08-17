using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;

namespace ENothi_Desktop.Ui
{
    public partial class DakMovementShowUi : Form
    {
        public MovementStatusVm MovementStatusVm;
        public DakMovementShowUi()
        {
            InitializeComponent();
        }

        public DakMovementShowUi(MovementStatusVm dakMovementStatusVm) : this()
        {
            MovementStatusVm = dakMovementStatusVm;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DakMovementShowUi_Load(object sender, EventArgs e)
        {

        }

        private void DakMovementShowUi_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }

        protected override void OnLoad(EventArgs e)
        {
            PlaceLowerRight();
            base.OnLoad(e);
        }

        private void PlaceLowerRight()
        {
            //Determine "rightmost" screen
            //Screen rightmost = Screen.AllScreens[0];
            Screen rightmost = Screen.PrimaryScreen;
            //foreach (Screen screen in Screen.AllScreens)
            //{
            //    if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
            //        rightmost = screen;
            //}

            this.Left = rightmost.WorkingArea.Right - (this.Width+8);
            this.Top = rightmost.WorkingArea.Bottom - (this.Height+10);
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, topPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.White, 1, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }
    }
}
