using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Interface.IManager;
using ENothi_Desktop.Manager;
using ENothi_Desktop.Models;
using ENothi_Desktop.Utilities;

namespace ENothi_Desktop.Ui
{
    public partial class DashboardUi : Form
    {
        private readonly IDakInboxManager _dakInboxManager;
        private readonly LoginResponse _loginResponse;
        public DashboardUi()
        {
            InitializeComponent();
            _dakInboxManager = new DakInboxManager();
        }

        public DashboardUi(LoginResponse loginResponse) : this()
        {
            _loginResponse = loginResponse;
        }

        private void DashboardUi_Load(object sender, EventArgs e)
        {
            try
            {
                dakUploadButtonPannel.Height = dakUploadButton.Height;
                LoadModulePendingCount();
                LoadProfileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadProfileName()
        {
            var nameWithDesignation = _loginResponse.Data.EmployeeInfo.NameBng + " (" +
                                      _loginResponse.Data.OfficeInfo.FirstOrDefault().Designation + "," +
                                      _loginResponse.Data.OfficeInfo.FirstOrDefault().UnitNameBn + " )";
            profilerButton.Text = nameWithDesignation;
        }
        private void LoadModulePendingCount()
        {
            ModuleCountDto moduleCountRequest = new ModuleCountDto();
            moduleCountRequest.OfficeId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeId;
            moduleCountRequest.DesignationId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeUnitOrganogramId;
            string token = _loginResponse.Data.Token;
            var pendingCount = _dakInboxManager.GetPendingModuleCount(moduleCountRequest, token);
            dakCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(pendingCount.DesignationWiseDakNo.ToString());
            nothiCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(
                (pendingCount.DesignationWiseOtherOfficeNothiNo + pendingCount.DesignationWiseOwnOfficeNothiNo)
                .ToString());
        }

        private void dakUploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                ExpandOrCollapseDakUploadButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExpandOrCollapseDakUploadButton()
        {
            dakUploadButtonPannel.Height = dakUploadButtonPannel.Height == dakUploadButtonPannel.MinimumSize.Height ? dakUploadButtonPannel.MaximumSize.Height : dakUploadButton.Height;
        }

        private void paginationPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, paginationPanel.ClientRectangle,
                Color.White, 1, ButtonBorderStyle.Solid, // left
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid, // top
                Color.White, 1, ButtonBorderStyle.Solid, // right
                Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid);// bottom
        }


    }
}
