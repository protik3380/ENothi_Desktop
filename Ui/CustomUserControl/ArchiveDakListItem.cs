using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
using ENothi_Desktop.Utilities;

namespace ENothi_Desktop.Ui.CustomUserControl
{
    public partial class ArchiveDakListItem : UserControl
    {

        private bool _isButtonPanelView = false;
        [Category("Custom Props")]
        public DakInbox DakInbox { get; set; }
        [Category("Custom Props")]
        public DakInboxRecord Records { get; set; }
        private readonly IDakInboxManager _dakInboxManager;
        public ArchiveDakListItem()
        {
            InitializeComponent();
            _dakInboxManager = new DakInboxManager();
        }

        private void ArchiveDakListItem_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRowData();
                HideArchiveActionButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HideArchiveActionButton()
        {
            dakMovementButton.Visible = false;
            archiveRevertBackButton.Visible = false;
            dakTagButton.Visible = false;
        }

        private void ShowArchiveActionButton()
        {
            dakMovementButton.Visible = true;
            archiveRevertBackButton.Visible = true;
            dakTagButton.Visible = true;
        }

        private void LoadRowData()
        {
            if (Records.AttachmentCount > 0)
            {
                attachmentButton.Text = BengaliTextFormatter.ConvertToBengali(Records.AttachmentCount.ToString());
                attachmentButton.Visible = true;
            }
            else
            {
                attachmentButton.Visible = false;
            }
            utshoName.Text = Records.DakUser.DakType == "Daptorik" ? Records.DakOrigin.SenderName : Records.DakOrigin.NameBng;
            PraprokLabel.Text = Records.MovementStatus.To.FirstOrDefault(x => x.AttentionType == "1")?.Officer;
            prerokLabel.Text = Records.MovementStatus.From.Officer;
            if (Records.DakUser.DakSubject.Length > 70)
            {
                var firstPart = Records.DakUser.DakSubject.Substring(0, 70);
                var secPart = Records.DakUser.DakSubject.Substring(70, Records.DakUser.DakSubject.Length - 70);
                var subject = firstPart + '\n' + secPart;
                subjectLabel.Text = subject;
            }
            else
            {
                subjectLabel.Text = Records.DakUser.DakSubject;
            }
            decesionLabel.Text = Records.DakUser.DakDecision;
            praporkOrOnulipiLabel.Text = Records.DakUser.AttentionType == "0" ? "অনুলিপি" : "মুল প্রাপক";
            securityLabel.Text = SecurityLevelGenerator.GenerateSecurityLevel(Records.DakUser.DakSecurity);
            priorityLabel.Text = PriorityLevelGenerator.GeneratePriorityLevel(Records.DakUser.DakPriority);
            nothiLabel.Text = Records.DakUser.DakOrigin.ToUpper();
            nagorikOrdaptorikLabel.Text = Records.DakUser.DakType == "Daptorik" ? "দাপ্তরিক" : "নাগরিক";
            dakTypeIcon.Image = Records.DakUser.DakType == "Daptorik"
                ? Properties.Resources.building
                : Properties.Resources.user;
            if (Records.DakUser.DakViewStatus == "New")
            {
                newLabel.Visible = true;
            }

            if (Records.Nothi.NothiNo!=null)
            {
                nlabel.Visible = true;
                nothiNoLabel.Visible = true;
                nothiNoLabel.Text = Records.Nothi.NothiNo;
            }
            else
            {
                nlabel.Visible = false;
                nothiNoLabel.Visible = false;
            }
        }

        private void label4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, newLabel.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
        private void utshoName_MouseEnter(object sender, EventArgs e)
        {
            var yourToolTip = new ToolTip();
            yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;
            string toolTipText = GetToolTipTextForUtshoName();
            yourToolTip.SetToolTip(utshoName, toolTipText);
        }

        private string GetToolTipTextForUtshoName()
        {
            string toolTip = String.Empty;
            if (Records.DakUser.DakType == "Daptorik")
            {
                toolTip = @"উৎস:" + Records.DakOrigin.SenderName + "," + Records.DakOrigin.SenderOfficerDesignationLabel + '\n'
                          + Records.DakOrigin.SenderOfficeUnitName + "," + Records.DakOrigin.SenderOfficeName + '\n' +
                          @"মূল প্রাপক:" + Records.DakOrigin.ReceivingOfficerName + '\n'
                          + Records.DakOrigin.ReceivingOfficerDesignationLabel + @"," +
                          Records.DakOrigin.ReceivingOfficeUnitName + '\n'
                          + Records.DakOrigin.ReceivingOfficeName;
            }
            else
            {
                toolTip = @"মূল প্রাপক:" + Records.DakOrigin.ReceivingOfficerName + '\n'
                          + Records.DakOrigin.ReceivingOfficerDesignationLabel + @"," +
                          Records.DakOrigin.ReceivingOfficeUnitName + '\n'
                          + Records.DakOrigin.ReceivingOfficeName;
            }

            return toolTip;
        }
        private void prerokLabel_MouseEnter(object sender, EventArgs e)
        {
            var yourToolTip = new ToolTip();
            yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;
            string toolTipText = GetToolTipTextForPrerokName();
            yourToolTip.SetToolTip(prerokLabel, toolTipText);
        }
        private string GetToolTipTextForPrerokName()
        {
            string toolTip = Records.MovementStatus.From.Designation + '\n'
                                                                     + Records.MovementStatus.From.OfficeUnit + @"," +
                                                                     Records.MovementStatus.From.Office;
            return toolTip;
        }

        private void PraprokLabel_MouseEnter(object sender, EventArgs e)
        {
            var yourToolTip = new ToolTip();
            yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;
            string toolTipText = GetToolTipTextForPrapokName();
            yourToolTip.SetToolTip(PraprokLabel, toolTipText);
        }
        private string GetToolTipTextForPrapokName()
        {
            var data = Records.MovementStatus.To.FirstOrDefault(x => x.AttentionType == "1");
            string toolTip = data?.Designation + @"," + data?.OfficeUnit + '\n'
                             + data?.Office;
            return toolTip;
        }

        private void attachmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                DakAttachmentDto request = new DakAttachmentDto
                {
                    DesignationId = ParameterHelper.DesignationId,
                    OfficeId = ParameterHelper.OfficeId,
                    DakId = Records.DakUser.DakId,
                    DakType = Records.DakUser.DakType,
                    IsCopiedDak = Records.DakUser.IsCopiedDak
                };
                DakAttachmentVm attachmentVm = _dakInboxManager.GetDakAttachmentListByDakId(request);
                ShowDakAttachmentUi showDakAttachmentUi = new ShowDakAttachmentUi(attachmentVm, Records.AttachmentCount.ToString());
                showDakAttachmentUi.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dakMovementButton_Click(object sender, EventArgs e)
        {
            try
            {
                DakMovementDto request = new DakMovementDto
                {
                    DesignationId = ParameterHelper.DesignationId,
                    OfficeId = ParameterHelper.OfficeId,
                    DakId = Records.DakUser.DakId,
                    DakType = Records.DakUser.DakType,
                    IsCopiedDak = Records.DakUser.IsCopiedDak
                };
                MovementStatusVm dakMovementStatus = _dakInboxManager.GetDakMovementStatusByDakId(request);
                DakMovementShowUi dakMovementShowUi = new DakMovementShowUi(dakMovementStatus);
                dakMovementShowUi.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ArchiveDakListItem_MouseLeave(object sender, EventArgs e)
        {
            HideArchiveActionButton();
        }

        private void ArchiveDakListItem_MouseEnter(object sender, EventArgs e)
        {
            ShowArchiveActionButton();
        }

        private void dakActionPanel_MouseEnter(object sender, EventArgs e)
        {
            ShowArchiveActionButton();
        }

        private void archiveRevertBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                DakArchiveRevertAlertUi dakArchiveRevertAlertUi = new DakArchiveRevertAlertUi(Records);
                dakArchiveRevertAlertUi.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
