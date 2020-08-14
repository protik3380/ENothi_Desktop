using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class From
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }

        [JsonProperty("office_unit_id")]
        public int OfficeUnitId { get; set; }

        [JsonProperty("designation_id")]
        public int DesignationId { get; set; }

        [JsonProperty("officer_id")]
        public int OfficerId { get; set; }

        [JsonProperty("office")]
        public string Office { get; set; }

        [JsonProperty("office_unit")]
        public string OfficeUnit { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("officer")]
        public string Officer { get; set; }
    }
}
