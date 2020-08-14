using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class Nothi
    {
        [JsonProperty("nothi_master_id")]
        public int? NothiMasterId { get; set; }

        [JsonProperty("nothi_note_id")]
        public int? NothiNoteId { get; set; }

        [JsonProperty("nothi_potro_id")]
        public int? NothiPotroId { get; set; }

        [JsonProperty("dak_id")]
        public int? DakId { get; set; }

        [JsonProperty("dak_type")]
        public string DakType { get; set; }

        [JsonProperty("is_copied_dak")]
        public int? IsCopiedDak { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("nothi_no")]
        public string NothiNo { get; set; }

        [JsonProperty("office_id")]
        public int? OfficeId { get; set; }

        [JsonProperty("office_name")]
        public string OfficeName { get; set; }

        [JsonProperty("office_unit_id")]
        public int? OfficeUnitId { get; set; }

        [JsonProperty("office_unit_name")]
        public string OfficeUnitName { get; set; }
    }
}
