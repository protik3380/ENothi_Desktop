using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENothi_Desktop.ApiUtility;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Interface.IManager;
using ENothi_Desktop.Manager;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;
using ENothi_Desktop.Ui.AlertUi;

namespace ENothi_Desktop.Ui
{
    public partial class DakArchiveAlertUi : Form
    {
        private readonly DakInboxRecord _dakInboxRecord;
        private readonly IDakActionManager _dakActionManager;
        public DakArchiveAlertUi()
        {
            InitializeComponent();
            _dakActionManager = new DakActionManager();
        }
        public DakArchiveAlertUi(DakInboxRecord record) : this()
        {
            _dakInboxRecord = record;
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
            Left = (point.X + 60) - this.Width;
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

        private void yesButton_Click(object sender, EventArgs e)
        {
            try
            {
                DakActionArchiveDto requestDto = new DakActionArchiveDto
                {
                    DesignationId = ParameterHelper.DesignationId,
                    OfficeId = ParameterHelper.OfficeId,
                    DakId = _dakInboxRecord.DakUser.DakId,
                    DakType = _dakInboxRecord.DakUser.DakType
                };
                bool response = _dakActionManager.DakArchive(requestDto);
                if (response)
                {                  
                    ReloadHelper.IsArchive = true;
                    this.Hide();
                    Form_Success frm = new Form_Success(@"ডাকটি সফলভাবে আর্কাইভ করা হয়েছে");
                    frm.Show();
                    this.Close();
                }                              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
