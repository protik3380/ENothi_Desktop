using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class MovementStatus
    {
        [JsonProperty("other")]
        public Other Other { get; set; }

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("to")]
        public List<To> To { get; set; }
    }
}
