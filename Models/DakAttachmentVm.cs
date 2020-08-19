using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models
{
    public class DakAttachmentVm
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<DakAttachment.DakAttachment> Records { get; set; }
    }
}
