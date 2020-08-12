using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models
{
   public class OfficeInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_record_id")]
        public int EmployeeRecordId { get; set; }

        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("office_unit_id")]
        public int OfficeUnitId { get; set; }

        [JsonProperty("office_unit_organogram_id")]
        public int OfficeUnitOrganogramId { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("designation_level")]
        public int DesignationLevel { get; set; }

        [JsonProperty("designation_sequence")]
        public int DesignationSequence { get; set; }

        [JsonProperty("office_head")]
        public int OfficeHead { get; set; }

        [JsonProperty("incharge_label")]
        public string InchargeLabel { get; set; }

        [JsonProperty("joining_date")]
        public DateTime JoiningDate { get; set; }

        [JsonProperty("last_office_date")]
        public object LastOfficeDate { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("show_unit")]
        public int ShowUnit { get; set; }

        [JsonProperty("designation_en")]
        public string DesignationEn { get; set; }

        [JsonProperty("unit_name_bn")]
        public string UnitNameBn { get; set; }

        [JsonProperty("office_name_bn")]
        public string OfficeNameBn { get; set; }

        [JsonProperty("unit_name_en")]
        public string UnitNameEn { get; set; }

        [JsonProperty("office_name_en")]
        public string OfficeNameEn { get; set; }

        [JsonProperty("protikolpo_status")]
        public int ProtikolpoStatus { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }
    }
}
