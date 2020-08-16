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
using ENothi_Desktop.Utilities;

namespace ENothi_Desktop.Ui.CustomUserControl
{
    public partial class DesignationListItem : UserControl
    {

        [Category("Custom Props")]
        public DesignationVm DesignationVm { get; set; }

        public DesignationListItem()
        {
            InitializeComponent();
        }

        private void DesignationListItem_Load(object sender, EventArgs e)
        {
            try
            {
                LoadControlData();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadControlData()
        {
            designationNameLabel.Text = DesignationVm.Designation;
            officeName.Text = DesignationVm.UnitNameBn + @"," + DesignationVm.OfficeNameBn;
            nothiCountButton.Text = BengaliTextFormatter.ConvertToBengali((DesignationVm.DesignationWiseOtherOfficeNothiNo +
                                                                          DesignationVm.DesignationWiseOwnOfficeNothiNo).ToString()) + @" টি নথি";
            DakCountButton.Text = BengaliTextFormatter.ConvertToBengali(DesignationVm.DesignationWiseDakNo.ToString()) +
                                  @"টি ডাক";
        }
    }
}
