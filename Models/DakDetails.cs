using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Models.DakInbox;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models
{
    public class DakDetails
    {

        public int DakUserId { get; set; }

        [JsonProperty("dak_type")]
        public string DakType { get; set; }

        [JsonProperty("dak_id")]
        public int DakId { get; set; }

        [JsonProperty("is_copied_dak")]
        public int IsCopiedDak { get; set; }

        [JsonProperty("dak_origin")]
        public string DakOrigin { get; set; }

        [JsonProperty("action_office_id")]
        public int ActionOfficeId { get; set; }

        [JsonProperty("from_potrojari")]
        public int FromPotrojari { get; set; }

        [JsonProperty("to_office_id")]
        public int ToOfficeId { get; set; }

        [JsonProperty("to_office_name")]
        public string ToOfficeName { get; set; }

        [JsonProperty("to_office_unit_id")]
        public int ToOfficeUnitId { get; set; }

        [JsonProperty("to_office_unit_name")]
        public string ToOfficeUnitName { get; set; }

        [JsonProperty("to_office_address")]
        public string ToOfficeAddress { get; set; }

        [JsonProperty("to_officer_id")]
        public int ToOfficerId { get; set; }

        [JsonProperty("to_officer_name")]
        public string ToOfficerName { get; set; }

        [JsonProperty("to_officer_designation_id")]
        public int ToOfficerDesignationId { get; set; }

        [JsonProperty("to_officer_designation_label")]
        public string ToOfficerDesignationLabel { get; set; }

        [JsonProperty("no_of_times_dak_received")]
        public int NoOfTimesDakReceived { get; set; }

        [JsonProperty("dak_view_status")]
        public string DakViewStatus { get; set; }

        [JsonProperty("dak_priority")]
        public string DakPriority { get; set; }

        [JsonProperty("dak_security")]
        public string DakSecurity { get; set; }

        [JsonProperty("attention_type")]
        public string AttentionType { get; set; }

        [JsonProperty("dak_movement_sequence")]
        public int DakMovementSequence { get; set; }

        [JsonProperty("rollback_move_seq")]
        public int RollbackMoveSeq { get; set; }

        [JsonProperty("last_movement_date")]
        public string LastMovementDate { get; set; }

        [JsonProperty("is_archive")]
        public int IsArchive { get; set; }

        [JsonProperty("is_rollback_dak")]
        public int IsRollbackDak { get; set; }

        [JsonProperty("dak_category")]
        public string DakCategory { get; set; }

        [JsonProperty("is_summary_nothi")]
        public int DakUserIsSummaryNothi { get; set; }

        [JsonProperty("is_nisponno")]
        public int IsNisponno { get; set; }

        [JsonProperty("created")]
        public string DakUserCreated { get; set; }

        [JsonProperty("modified")]
        public string DakUserModified { get; set; }

        [JsonProperty("dak_subject")]
        public string DakUserDakSubject { get; set; }

        [JsonProperty("dak_decision")]
        public string DakDecision { get; set; }

        [JsonProperty("archived_dak_user_id")]
        public int ArchivedDakUserId { get; set; }

        public int DakOriginId { get; set; }

        [JsonProperty("docketing_no")]
        public int DocketingNo { get; set; }

        [JsonProperty("dak_subject")]
        public string DakSubject { get; set; }

        [JsonProperty("dak_type_id")]
        public int DakTypeId { get; set; }

        [JsonProperty("dak_received_no")]
        public string DakReceivedNo { get; set; }

        [JsonProperty("dak_priority_level")]
        public string DakPriorityLevel { get; set; }

        [JsonProperty("dak_security_level")]
        public string DakSecurityLevel { get; set; }

        [JsonProperty("name_eng")]
        public string NameEng { get; set; }

        [JsonProperty("name_bng")]
        public string NameBng { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("receive_date")]
        public string ReceiveDate { get; set; }

        [JsonProperty("nothi_master_id")]
        public int NothiMasterId { get; set; }

        [JsonProperty("dak_status")]
        public string DakStatus { get; set; }

        [JsonProperty("uploader_designation_id")]
        public int UploaderDesignationId { get; set; }

        [JsonProperty("application_origin")]
        public string ApplicationOrigin { get; set; }

        [JsonProperty("created")]
        public string DakOriginCreated { get; set; }

        [JsonProperty("modified")]
        public string DakOriginModified { get; set; }

        [JsonProperty("sender_sarok_no")]
        public string SenderSarokNo { get; set; }

        [JsonProperty("sender_office_id")]
        public int SenderOfficeId { get; set; }

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

        [JsonProperty("sending_date")]
        public string SendingDate { get; set; }

        [JsonProperty("sender_address")]
        public string SenderAddress { get; set; }

        [JsonProperty("sender_email")]
        public string SenderEmail { get; set; }

        [JsonProperty("sender_phone")]
        public string SenderPhone { get; set; }

        [JsonProperty("sender_mobile")]
        public string SenderMobile { get; set; }

        [JsonProperty("dak_sending_media")]
        public string DakSendingMedia { get; set; }

        [JsonProperty("receiving_date")]
        public string ReceivingDate { get; set; }

        [JsonProperty("dak_cover")]
        public string DakCover { get; set; }

        [JsonProperty("dak_description")]
        public string DakDescription { get; set; }

        [JsonProperty("meta_data")]
        public string MetaData { get; set; }

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

        [JsonProperty("is_summary_nothi")]
        public int DakOriginIsSummaryNothi { get; set; }

        [JsonProperty("previous_receipt_no")]
        public string PreviousReceiptNo { get; set; }

        [JsonProperty("previous_docketing_no")]
        public string PreviousDocketingNo { get; set; }

        [JsonProperty("is_rollback_to_dak")]
        public int IsRollbackToDak { get; set; }

        [JsonProperty("from_potrojari")]
        public int DakOriginFromPotrojari { get; set; }

        [JsonProperty("movement_status")]
        public MovementStatus MovementStatus { get; set; }

        [JsonProperty("attachment_count")]
        public int AttachmentCount { get; set; }
    }
}
