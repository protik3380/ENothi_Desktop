using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class Other
    {
        [JsonProperty("operation_type")]
        public string OperationType { get; set; }

        [JsonProperty("last_movement_date")]
        public string LastMovementDate { get; set; }

        [JsonProperty("dak_priority")]
        public int DakPriority { get; set; }

        [JsonProperty("dak_security_level")]
        public string DakSecurityLevel { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("dak_actions")]
        public string DakActions { get; set; }

        [JsonProperty("docketing_no")]
        public int DocketingNo { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
