using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Interface.IManager;
using ENothi_Desktop.Manager;
using ENothi_Desktop.Models;
using ENothi_Desktop.Ui.CustomUserControl;
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
                LoadModulePendingCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadModulePendingCount()
        {
            ModuleCountDto moduleCountRequest = new ModuleCountDto();
            moduleCountRequest.OfficeId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeId;
            moduleCountRequest.DesignationId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeUnitOrganogramId;
            string token = _loginResponse.Data.Token;
            var pendingCount = _dakInboxManager.GetPendingModuleCount(moduleCountRequest,token);
            dakCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(pendingCount.DesignationWiseDakNo.ToString());
            nothiCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(
                (pendingCount.DesignationWiseOtherOfficeNothiNo + pendingCount.DesignationWiseOwnOfficeNothiNo)
                .ToString());
        }


    }
}
