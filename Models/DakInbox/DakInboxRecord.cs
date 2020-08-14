using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class DakInboxRecord
    {
        [JsonProperty("dak_user")]
        public DakUser DakUser { get; set; }

        [JsonProperty("dak_origin")]
        public DakOrigin DakOrigin { get; set; }

        [JsonProperty("movement_status")]
        public MovementStatus MovementStatus { get; set; }

        [JsonProperty("attachment_count")]
        public int AttachmentCount { get; set; }

        [JsonProperty("nothi")]
        public Nothi Nothi { get; set; }
    }
}
