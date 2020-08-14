using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class DakInboxData
    {
        [JsonProperty("records")]
        public List<DakInboxRecord> Records { get; set; }

        [JsonProperty("total_records")]
        public int TotalRecords { get; set; }
    }
}
