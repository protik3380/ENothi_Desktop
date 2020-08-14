using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class DakUser
    {
        [JsonProperty("dak_id")]
        public int DakId { get; set; }

        [JsonProperty("dak_type")]
        public string DakType { get; set; }

        [JsonProperty("is_copied_dak")]
        public int IsCopiedDak { get; set; }

        [JsonProperty("dak_origin")]
        public string DakOrigin { get; set; }

        [JsonProperty("from_potrojari")]
        public int FromPotrojari { get; set; }

        [JsonProperty("dak_view_status")]
        public string DakViewStatus { get; set; }

        [JsonProperty("attention_type")]
        public string AttentionType { get; set; }

        [JsonProperty("dak_priority")]
        public string DakPriority { get; set; }

        [JsonProperty("dak_security")]
        public string DakSecurity { get; set; }

        [JsonProperty("dak_movement_sequence")]
        public int DakMovementSequence { get; set; }

        [JsonProperty("last_movement_date")]
        public string LastMovementDate { get; set; }

        [JsonProperty("dak_category")]
        public string DakCategory { get; set; }

        [JsonProperty("dak_subject")]
        public string DakSubject { get; set; }

        [JsonProperty("dak_decision")]
        public string DakDecision { get; set; }
    }
}
