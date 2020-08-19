using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Dto.RequestDto
{
    public class DakAttachmentDto
    {
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }
        [JsonProperty("designation_id")]
        public int DesignationId { get; set; }
        [JsonProperty("dak_id")]
        public int DakId { get; set; }
        [JsonProperty("dak_type")]
        public string DakType { get; set; }
        [JsonProperty("is_copied_dak")]
        public int IsCopiedDak { get; set; }
    }
}
