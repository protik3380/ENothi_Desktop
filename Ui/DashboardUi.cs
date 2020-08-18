using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ENothi_Desktop.ApiUtility;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Interface.IManager;
using ENothi_Desktop.Manager;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;
using ENothi_Desktop.Ui.CustomUserControl;
using ENothi_Desktop.Utilities;

namespace ENothi_Desktop.Ui
{
    public partial class DashboardUi : Form
    {
        private readonly IDakInboxManager _dakInboxManager;
        private readonly LoginResponse _loginResponse;
        private DakInbox _dakInbox;
        public List<DesignationVm> DesignationVm;
        public DashboardUi()
        {
            InitializeComponent();
            _dakInboxManager = new DakInboxManager();
            DesignationVm = new List<DesignationVm>();
        }

        public DashboardUi(LoginResponse loginResponse) : this()
        {
            _loginResponse = loginResponse;
        }

        private void DashboardUi_Load(object sender, EventArgs e)
        {
            try
            {

                firstCombo.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                dakUploadButtonPannel.Height = dakUploadButton.Height;
                SetParameterHelper();
                GetAllDesignationData();
                LoadModulePendingCount();
                LoadProfileName();                                              
                GetDakInboxListData();
                PopulateDakList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetAllDesignationData()
        {
            foreach (var officeInfo in _loginResponse.Data.OfficeInfo)
            {
                ModuleCountDto requestDto = new ModuleCountDto
                {
                    DesignationId = officeInfo.OfficeUnitOrganogramId,
                    OfficeId = officeInfo.OfficeId
                };
                var count = _dakInboxManager.GetPendingModuleCount(requestDto);
                DesignationVm designationVm = new DesignationVm();
                designationVm.Designation = officeInfo.Designation;
                designationVm.OfficeId = officeInfo.OfficeId;
                designationVm.OfficeUnitOrganogramId = officeInfo.OfficeUnitOrganogramId;
                designationVm.OfficeNameBn = officeInfo.OfficeNameBn;
                designationVm.UnitNameBn = officeInfo.UnitNameBn;
                if (count != null)
                {
                    designationVm.DesignationWiseDakNo = count.DesignationWiseDakNo;
                    designationVm.DesignationWiseOtherOfficeNothiNo = count.DesignationWiseOtherOfficeNothiNo;
                    designationVm.DesignationWiseOwnOfficeNothiNo = count.DesignationWiseOwnOfficeNothiNo;
                    designationVm.TotalDakNo = count.TotalDakNo;
                    designationVm.TotalOwnOfficeNothiNo = count.TotalOwnOfficeNothiNo;
                    designationVm.TotalOtherOfficeNothiNo = count.TotalOtherOfficeNothiNo;
                }               
                DesignationVm.Add(designationVm);
            }
        }

        private void SetParameterHelper()
        {
            ParameterHelper.OfficeId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeId;
            ParameterHelper.DesignationId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeUnitOrganogramId;
            ParameterHelper.Token = _loginResponse.Data.Token;
        }
        private void GetDakInboxListData()
        {
            DakInboxDto request = new DakInboxDto();
            request.DesignationId = ParameterHelper.DesignationId;
            request.OfficeId = ParameterHelper.OfficeId;
            request.PageNo = 1;
            request.Limit = 20;
            _dakInbox = _dakInboxManager.GetDakInboxListData(request);
        }
        private void PopulateDakList()
        {
            if (_dakInbox.Data!=null)
            {
                ListItem[] listItems = new ListItem[_dakInbox.Data.Records.Count];
                for (int i = 0; i < listItems.Length; i++)
                {
                    listItems[i] = new ListItem();
                    listItems[i].DakInbox = _dakInbox;
                    listItems[i].Records = _dakInbox.Data.Records[i];
                    if (DakListFlowPanel.Controls.Count < 0)
                    {
                        DakListFlowPanel.Controls.Clear();
                    }
                    else
                    {
                        DakListFlowPanel.Controls.Add(listItems[i]);

                    }
                }
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

            dakCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(DesignationVm.FirstOrDefault().DesignationWiseDakNo.ToString());
            nothiCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(
                (DesignationVm.FirstOrDefault().DesignationWiseOtherOfficeNothiNo + DesignationVm.FirstOrDefault().DesignationWiseOwnOfficeNothiNo)
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

        private void profilerButton_Click(object sender, EventArgs e)
        {
            try
            {
                //DesignationSelectionUi designationSelectionUi = new DesignationSelectionUi(false,true);
                //designationSelectionUi.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void profileImage_Click(object sender, EventArgs e)
        {
            try
            {
                DesignationSelectionUi designationSelectionUi = new DesignationSelectionUi(true, false,DesignationVm);
                designationSelectionUi.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void agatoDakButton_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveAgatoDakButton();
                DakListFlowPanel.Controls.Clear();
                //GetDakInboxListData();
                PopulateDakList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void archiveDakViewSidePanelButton_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveArchiveDakButton();
                DakListFlowPanel.Controls.Clear();

                DakInboxDto request = new DakInboxDto();
                request.DesignationId = ParameterHelper.DesignationId;
                request.OfficeId = ParameterHelper.OfficeId;
                request.PageNo = 1;
                request.Limit = 20;
                var archiveDakListData = _dakInboxManager.GetArchiveDakListData(request);
                PopulateArchiveDakListData(archiveDakListData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PopulateArchiveDakListData(DakInbox archiveDakListData)
        {
            if (archiveDakListData.Data != null)
            {
                ArchiveDakListItem[] listItems = new ArchiveDakListItem[archiveDakListData.Data.Records.Count];
                for (int i = 0; i < listItems.Length; i++)
                {
                    listItems[i] = new ArchiveDakListItem();
                    listItems[i].DakInbox = archiveDakListData;
                    listItems[i].Records = archiveDakListData.Data.Records[i];
                    if (DakListFlowPanel.Controls.Count < 0)
                    {
                        DakListFlowPanel.Controls.Clear();
                    }
                    else
                    {
                        DakListFlowPanel.Controls.Add(listItems[i]);

                    }
                }
            }
        }

        private void ActiveArchiveDakButton()
        {
            agatoDakViewSidePanelButton.ForeColor = DefaultForeColor;
            archiveDakViewSidePanelButton.ForeColor = Color.FromArgb(113, 182, 253);
            bachaikritoDakViewSidePanelButton.ForeColor = DefaultForeColor;
        }

        private void ActiveAgatoDakButton()
        {
            agatoDakViewSidePanelButton.ForeColor = Color.FromArgb(113, 182, 253); 
            archiveDakViewSidePanelButton.ForeColor = DefaultForeColor;
            bachaikritoDakViewSidePanelButton.ForeColor = DefaultForeColor;
        }

        private void firstCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
            }
            e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                e.Font,
                new SolidBrush(Color.Black),
                new Point(e.Bounds.X, e.Bounds.Y));
        }
    }
}
