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
using ENothi_Desktop.Ui.CustomUserControl;

namespace ENothi_Desktop.Ui
{
    public partial class DesignationSelectionUi : Form
    {
        private bool _isButtonClick;
        private bool _isImageClick;
        private List<DesignationVm> _designationList;
        
        public DesignationSelectionUi()
        {
            InitializeComponent();
        }

        public DesignationSelectionUi(bool isImageClick,bool isButtonClick,List<DesignationVm>designationList) : this()
        {
            _isButtonClick = isButtonClick;
            _isImageClick = isImageClick;
            _designationList = designationList;
        }
        private void DesignationSelectionUi_Load(object sender, EventArgs e)
        {
            var point = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            if (_isImageClick)
            {
                Top = point.Y + 30;
                Left = point.X  - this.Width;
            }
            if (_isButtonClick)
            {
                Top = point.Y + 30;
                Left = point.X - this.Width/2;
            }

            LoadDesignationUserControl();

        }

        private void LoadDesignationUserControl()
        {
            if (_designationList != null)
            {
                DesignationListItem[] listItems = new DesignationListItem[_designationList.Count];
                for (int i = 0; i < listItems.Length; i++)
                {
                    listItems[i] = new DesignationListItem();
                    listItems[i].DesignationVm = _designationList[i];
                    if (flowLayoutPanel1.Controls.Count < 0)
                    {
                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(listItems[i]);
                    }
                }
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
