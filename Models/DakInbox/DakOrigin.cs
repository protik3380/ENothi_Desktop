using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakInbox
{
    public class DakOrigin
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sender_officer_id")]
        public int SenderOfficerId { get; set; }

        [JsonProperty("sender_office_name")]
        public string SenderOfficeName { get; set; }

        [JsonProperty("sender_office_unit_id")]
        public int SenderOfficeUnitId { get; set; }

        [JsonProperty("sender_office_unit_name")]
        public string SenderOfficeUnitName { get; set; }

        [JsonProperty("sender_officer_designation_id")]
        public int SenderOfficerDesignationId { get; set; }

        [JsonProperty("sender_officer_designation_label")]
        public string SenderOfficerDesignationLabel { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("receiving_office_id")]
        public int ReceivingOfficeId { get; set; }

        [JsonProperty("receiving_office_name")]
        public string ReceivingOfficeName { get; set; }

        [JsonProperty("receiving_office_unit_id")]
        public int ReceivingOfficeUnitId { get; set; }

        [JsonProperty("receiving_office_unit_name")]
        public string ReceivingOfficeUnitName { get; set; }

        [JsonProperty("receiving_officer_id")]
        public int ReceivingOfficerId { get; set; }

        [JsonProperty("receiving_officer_designation_id")]
        public int ReceivingOfficerDesignationId { get; set; }

        [JsonProperty("receiving_officer_designation_label")]
        public string ReceivingOfficerDesignationLabel { get; set; }

        [JsonProperty("receiving_officer_name")]
        public string ReceivingOfficerName { get; set; }

        [JsonProperty("docketing_no")]
        public int DocketingNo { get; set; }

        [JsonProperty("dak_received_no")]
        public string DakReceivedNo { get; set; }

        [JsonProperty("sender_sarok_no")]
        public string SenderSarokNo { get; set; }

        [JsonProperty("receiving_date")]
        public string ReceivingDate { get; set; }

        [JsonProperty("name_eng")]
        public string NameEng { get; set; }

        [JsonProperty("name_bng")]
        public string NameBng { get; set; }
    }
}
