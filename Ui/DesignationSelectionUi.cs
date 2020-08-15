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
    public partial class DesignationSelectionUi : Form
    {
        private bool _isButtonClick;
        private bool _isImageClick;
        
        public DesignationSelectionUi()
        {
            InitializeComponent();
        }

        public DesignationSelectionUi(bool isImageClick,bool isButtonClick) : this()
        {
            _isButtonClick = isButtonClick;
            _isImageClick = isImageClick;
        }
        private void DesignationSelectionUi_Load(object sender, EventArgs e)
        {
            var _point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            if (_isImageClick)
            {
                Top = _point.Y + 30;
                Left = _point.X  - this.Width;
            }
            if (_isButtonClick)
            {
                Top = _point.Y + 30;
                Left = _point.X - this.Width/2;
            }

        }

        private void DesignationSelectionUi_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, topPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }

        private void DesignationSelectionUi_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }
    }
}
