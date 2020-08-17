using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Models.DakInbox;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models
{
    public class MovementStatusVm
    {
        [JsonProperty("records")]
        public List<MovementStatus> Records { get; set; }

        [JsonProperty("total_records")]
        public int TotalRecords { get; set; }
    }
}
