using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;
using ENothi_Desktop.Utilities;

namespace ENothi_Desktop.Ui.CustomUserControl
{
    public partial class DakMovementList : UserControl
    {
        [Category("Custom Props")]
        public MovementStatus Records { get; set; }
        public DakMovementList()
        {
            InitializeComponent();
        }

        private void DakMovementList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRowData();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadRowData()
        {
            LoadDakActionLabel();
            LoadDakPriorityLabelAndIcon();
            LoadDakSecurityLabelAndIcon();
            LoadPrerokDesignationInfoLabel();
            if (Records.Other.OperationType== "Forward")
            {
                LoadMulPrapokNameAndDesignationInfo();
            }
            else
            {
                mulPrapokNameLabel.Visible = false;
                mulPrapokDesignationInfoLabel.Visible = false;
                contentPanel.Height = 167;
                this.Height = 215;
            }
           
            prerokNameLabel.Text = Records.From.Officer;
        }

        private void LoadMulPrapokNameAndDesignationInfo()
        {
            var mulprapokInfo = Records.To.Where(x => x.AttentionType == "1").ToList();
            if (mulprapokInfo.Count>0)
            {
                mulPrapokNameLabel.Text = mulprapokInfo.FirstOrDefault()?.Officer;
                string designationInfo = mulprapokInfo.FirstOrDefault()?.Designation + "," +
                                         mulprapokInfo.FirstOrDefault()?.OfficeUnit + "," +
                                         mulprapokInfo.FirstOrDefault()?.Office;
                mulPrapokDesignationInfoLabel.Text = designationInfo;
            }
            else
            {
                mulPrapokNameLabel.Visible = false;
                mulPrapokDesignationInfoLabel.Visible = false;
            }
        }

        private void LoadPrerokDesignationInfoLabel()
        {
            string designationInfo =
                Records.From.Designation + @"," + Records.From.OfficeUnit + @"," + Records.From.Office;
            prerokDesignationInfoLabel.Text = designationInfo;
        }

        private void LoadDakSecurityLabelAndIcon()
        {
            if (Records.Other.DakSecurityLevel !="" && Records.Other.DakSecurityLevel != "0")
            {
                securityLabel.Text =
                    SecurityLevelGenerator.GenerateSecurityLevel(Records.Other.DakSecurityLevel);
            }
            else
            {
                securityLabel.Visible = false;
                securityPicBox.Visible = false;
            }
        }

        private void LoadDakPriorityLabelAndIcon()
        {
            if (Records.Other.DakPriority > 1)
            {
                priorityLabel.Text =
                    PriorityLevelGenerator.GeneratePriorityLevel(Records.Other.DakPriority.ToString());
            }
            else
            {
                priorityLabel.Visible = false;
                PriorityPicbox.Visible = false;
            }
        }

        private void LoadDakActionLabel()
        {
            if (Records.Other.DakActions != "")
            {
                dakAction.Text = Records.Other.DakActions;
            }
            else
            {
                dakAction.Visible = false;
            }
        }
    }
}
