using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models
{
    public class EmployeeInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name_eng")]
        public string NameEng { get; set; }

        [JsonProperty("name_bng")]
        public string NameBng { get; set; }

        [JsonProperty("father_name_eng")]
        public string FatherNameEng { get; set; }

        [JsonProperty("father_name_bng")]
        public string FatherNameBng { get; set; }

        [JsonProperty("mother_name_eng")]
        public string MotherNameEng { get; set; }

        [JsonProperty("mother_name_bng")]
        public string MotherNameBng { get; set; }

        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("nid")]
        public string Nid { get; set; }

        [JsonProperty("bcn")]
        public string Bcn { get; set; }

        [JsonProperty("ppn")]
        public string Ppn { get; set; }

        [JsonProperty("personal_email")]
        public string PersonalEmail { get; set; }

        [JsonProperty("personal_mobile")]
        public string PersonalMobile { get; set; }

        [JsonProperty("is_cadre")]
        public int IsCadre { get; set; }

        [JsonProperty("joining_date")]
        public object JoiningDate { get; set; }

        [JsonProperty("default_sign")]
        public int DefaultSign { get; set; }
    }
}
