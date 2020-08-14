using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Dto.RequestDto
{
    public class DakInboxDto
    {
        [JsonProperty("designation_id")]
        public int DesignationId { get; set; }
        [JsonProperty("office_id")]
        public int OfficeId { get; set; }
        [JsonProperty("page")]
        public int PageNo { get; set; }
        [JsonProperty("limit")]
        public int Limit { get; set; }

    }
}
