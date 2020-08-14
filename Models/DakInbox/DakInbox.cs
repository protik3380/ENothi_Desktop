using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class DakInbox
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public DakInboxData Data { get; set; }
    }
}
