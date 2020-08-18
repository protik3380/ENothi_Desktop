using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENothi_Desktop.Interface.IManager;
using ENothi_Desktop.Manager;
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
                //HideDakActionButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            utshoName.Text = Records.DakOrigin.SenderName;
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

            if (Records.Nothi!=null)
            {
                nlabel.Visible = true;
                nothiNoLabel.Visible = true;
                nothiNoLabel.Text = Records.Nothi.NothiNo;
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
            string toolTip = @"মূল প্রাপক:" + Records.DakOrigin.ReceivingOfficerName + '\n'
                             + Records.DakOrigin.ReceivingOfficerDesignationLabel + @"," +
                             Records.DakOrigin.ReceivingOfficeUnitName + '\n'
                             + Records.DakOrigin.ReceivingOfficeName;
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
                ShowDakAttachmentUi showDakAttachmentUi = new ShowDakAttachmentUi();
                showDakAttachmentUi.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
