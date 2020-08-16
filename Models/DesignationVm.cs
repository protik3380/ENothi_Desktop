using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENothi_Desktop.Models
{
    public class DesignationVm
    {
        public int OfficeUnitOrganogramId { get; set; }
        public int OfficeId { get; set; }
        public string Designation { get; set; }
        public string UnitNameBn { get; set; }
        public string OfficeNameBn { get; set; }
        public int DesignationWiseDakNo { get; set; }
        public int DesignationWiseOwnOfficeNothiNo { get; set; }
        public int DesignationWiseOtherOfficeNothiNo { get; set; }
        public int TotalDakNo { get; set; }
        public int TotalOwnOfficeNothiNo { get; set; }
        public int TotalOtherOfficeNothiNo { get; set; }
    }
}
