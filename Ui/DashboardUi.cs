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
        public WaitFormFunc WaitForm;
        public Page Page;
        private bool _isAgatoDakActive;
        private bool _isArchiveDakActive;
        public DashboardUi()
        {
            InitializeComponent();
            _dakInboxManager = new DakInboxManager();
            DesignationVm = new List<DesignationVm>();
            WaitForm = new WaitFormFunc();
            Page = new Page();
            _isAgatoDakActive = false;
            _isArchiveDakActive = false;

        }

        public DashboardUi(LoginResponse loginResponse) : this()
        {
            _loginResponse = loginResponse;
        }

        private void DashboardUi_Load(object sender, EventArgs e)
        {
            try
            {
                ActiveAgatoDakButton();
                firstCombo.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;             
                dakUploadButtonPannel.Height = dakUploadButton.Height;
                WaitForm.Show(this);
                SetParameterHelper();
                DesignationVm = GetAllDesignationData();
                LoadModulePendingCount(DesignationVm);
                LoadProfileName();
                _dakInbox = GetDakInboxListData(Convert.ToInt32(Page.CurrentPage), Convert.ToInt32(Page.PageSize));
                Page.ToIndex = _dakInbox.Data.Records.Count();
                Page.TotalRecords = _dakInbox.Data.TotalRecords;
                SetPageLabel(Page.FromIndex, Page.ToIndex, Page.TotalRecords);
                PopulateDakList(_dakInbox);
                WaitForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetPageLabel(decimal pageFromIndex, decimal pageToIndex, decimal pageTotalRecords)
        {
            if (pageTotalRecords > 0)
            {
                pageFromIndex++;
                string pageText = BengaliTextFormatter.ConvertToBengali(pageFromIndex.ToString()) + " - "
                                 + BengaliTextFormatter.ConvertToBengali(pageToIndex.ToString()) + " সর্বমোট: " +
                                  BengaliTextFormatter.ConvertToBengali(pageTotalRecords.ToString());
                pagingLabel.Text = pageText;
                
            }

        }

        private void DashboardUi_Activated(object sender, EventArgs e)
        {
            try
            {
                if (ReloadHelper.IsReloadRequired)
                {
                    WaitForm.Show(this);
                    //ActiveAgatoDakButton();
                    DakListFlowPanel.Controls.Clear();
                    var designationList = GetAllDesignationData();
                    LoadModulePendingCount(designationList);
                    //LoadProfileName();
                    Page = new Page();
                    var dakListData = GetDakInboxListData(Convert.ToInt32(Page.CurrentPage), Convert.ToInt32(Page.PageSize));
                    Page.ToIndex = dakListData.Data.Records.Count();
                    Page.TotalRecords = dakListData.Data.TotalRecords;
                    SetPageLabel(Page.FromIndex, Page.ToIndex, Page.TotalRecords);
                    PopulateDakList(dakListData);
                    ResetReloadHelper();
                    WaitForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetReloadHelper()
        {
            ReloadHelper.IsReloadRequired = false;
        }

        private List<DesignationVm> GetAllDesignationData()
        {
            List<DesignationVm> designationList = new List<DesignationVm>();
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
                designationList.Add(designationVm);
            }

            return designationList;
        }

        private void SetParameterHelper()
        {
            ParameterHelper.OfficeId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeId;
            ParameterHelper.DesignationId = _loginResponse.Data.OfficeInfo.FirstOrDefault().OfficeUnitOrganogramId;
            ParameterHelper.Token = _loginResponse.Data.Token;
        }
        private DakInbox GetDakInboxListData(int pageNo, int pageLimit)
        {
            DakInboxDto request = new DakInboxDto();
            request.DesignationId = ParameterHelper.DesignationId;
            request.OfficeId = ParameterHelper.OfficeId;
            request.PageNo = pageNo;
            request.Limit = pageLimit;
            var response = _dakInboxManager.GetDakInboxListData(request);
            return response;
        }
        private void PopulateDakList(DakInbox dakInbox)
        {
            if (dakInbox.Data != null)
            {
                ListItem[] listItems = new ListItem[dakInbox.Data.Records.Count];
                for (int i = 0; i < listItems.Length; i++)
                {
                    listItems[i] = new ListItem();
                    listItems[i].DakInbox = dakInbox;
                    listItems[i].Records = dakInbox.Data.Records[i];
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
        private void LoadModulePendingCount(List<DesignationVm> designationList)
        {

            dakCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(designationList.FirstOrDefault().DesignationWiseDakNo.ToString());
            nothiCounterLabel.Text = BengaliTextFormatter.ConvertToBengali(
                (designationList.FirstOrDefault().DesignationWiseOtherOfficeNothiNo + designationList.FirstOrDefault().DesignationWiseOwnOfficeNothiNo)
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

        private void profileImage_Click(object sender, EventArgs e)
        {
            try
            {
                var designationList = GetAllDesignationData();
                DesignationSelectionUi designationSelectionUi = new DesignationSelectionUi(true, false, designationList);
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
                WaitForm.Show(this);
                ActiveAgatoDakButton();
                DakListFlowPanel.Controls.Clear();

                var designationList = GetAllDesignationData();
                LoadModulePendingCount(designationList);
                Page = new Page();
                var dakListInbox = GetDakInboxListData(Convert.ToInt32(Page.CurrentPage), Convert.ToInt32(Page.PageSize));
                Page.ToIndex = dakListInbox.Data.Records.Count();
                Page.TotalRecords = dakListInbox.Data.TotalRecords;
                SetPageLabel(Page.FromIndex, Page.ToIndex, Page.TotalRecords);
                PopulateDakList(dakListInbox);
                WaitForm.Close();
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
                WaitForm.Show(this);
                ActiveArchiveDakButton();
                DakListFlowPanel.Controls.Clear();
                Page = new Page();
                var archiveDakListData = GetArchiveDakListData(Convert.ToInt32(Page.CurrentPage), Convert.ToInt32(Page.PageSize));
                Page.ToIndex = archiveDakListData.Data.Records.Count();
                Page.TotalRecords = archiveDakListData.Data.TotalRecords;
                SetPageLabel(Page.FromIndex, Page.ToIndex, Page.TotalRecords);
                PopulateArchiveDakListData(archiveDakListData);
                WaitForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DakInbox GetArchiveDakListData(int currentPage,int pageSize)
        {
            DakInboxDto request = new DakInboxDto();
            request.DesignationId = ParameterHelper.DesignationId;
            request.OfficeId = ParameterHelper.OfficeId;
            request.PageNo = currentPage;
            request.Limit = pageSize;
            var archiveDakListData = _dakInboxManager.GetArchiveDakListData(request);
            return archiveDakListData;
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
            _isAgatoDakActive = false;
            _isArchiveDakActive = true;
        }

        private void ActiveAgatoDakButton()
        {
            agatoDakViewSidePanelButton.ForeColor = Color.FromArgb(113, 182, 253);
            archiveDakViewSidePanelButton.ForeColor = DefaultForeColor;
            bachaikritoDakViewSidePanelButton.ForeColor = DefaultForeColor;
            _isAgatoDakActive = true;
            _isArchiveDakActive = false;
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

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {

        }
    }
}
