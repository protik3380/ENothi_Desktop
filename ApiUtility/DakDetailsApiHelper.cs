using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakAttachment;
using ENothi_Desktop.Models.DakInbox;
using Newtonsoft.Json.Linq;

namespace ENothi_Desktop.ApiUtility
{
    public static class DakDetailsApiHelper
    {
        public static DakDetails GetDakDetailsByDakId(DakDetailsDto request)
        {
            DakDetails dakDetails = new DakDetails();
            using (var client = new HttpClientDemo())
            {
                client.DefaultRequestHeaders.Add("api-version", "2");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ParameterHelper.Token);

                var postTask = client.PostAsJsonAsync("/api/dak/view", request);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    JObject responseData = JObject.Parse(data);
                    var dakUserObj = responseData["data"]["dak_user"];
                    dakDetails.DakUserId = (int)dakUserObj["id"];
                    dakDetails.DakType = (string)dakUserObj["dak_type"];
                    dakDetails.DakId = (int)dakUserObj["dak_id"];
                    dakDetails.IsCopiedDak = (int)dakUserObj["is_copied_dak"];
                    dakDetails.DakOrigin = (string)dakUserObj["dak_origin"];
                    dakDetails.ActionOfficeId = (int)dakUserObj["action_office_id"];
                    dakDetails.FromPotrojari = (int)dakUserObj["from_potrojari"];
                    dakDetails.ToOfficeId = (int)dakUserObj["to_office_id"];
                    dakDetails.ToOfficeName = (string)dakUserObj["to_office_name"];
                    dakDetails.ToOfficeUnitId = (int)dakUserObj["to_office_unit_id"];
                    dakDetails.ToOfficeUnitName = (string)dakUserObj["to_office_unit_name"];
                    dakDetails.ToOfficeAddress = (string)dakUserObj["to_office_address"];
                    dakDetails.ToOfficerId = (int)dakUserObj["to_officer_id"];
                    dakDetails.ToOfficerName = (string)dakUserObj["to_officer_name"];
                    dakDetails.ToOfficerDesignationId = (int)dakUserObj["to_officer_designation_id"];
                    dakDetails.ToOfficerDesignationLabel = (string)dakUserObj["to_officer_designation_label"];
                    dakDetails.NoOfTimesDakReceived = (int)dakUserObj["no_of_times_dak_received"];
                    dakDetails.DakViewStatus = (string)dakUserObj["dak_view_status"];
                    dakDetails.DakPriority = (string)dakUserObj["dak_priority"];
                    dakDetails.DakSecurity = (string)dakUserObj["dak_security"];
                    dakDetails.AttentionType = (string)dakUserObj["attention_type"];
                    dakDetails.DakMovementSequence = (int)dakUserObj["dak_movement_sequence"];
                    dakDetails.RollbackMoveSeq = (int)dakUserObj["rollback_move_seq"];
                    dakDetails.LastMovementDate = (string)dakUserObj["last_movement_date"];
                    dakDetails.IsArchive = (int)dakUserObj["is_archive"];
                    dakDetails.IsRollbackDak = (int)dakUserObj["is_rollback_dak"];
                    dakDetails.DakCategory = (string)dakUserObj["dak_category"];
                    dakDetails.DakUserIsSummaryNothi = (int)dakUserObj["is_summary_nothi"];
                    dakDetails.IsNisponno = (int)dakUserObj["is_nisponno"];
                    dakDetails.DakUserCreated = (string)dakUserObj["created"];
                    dakDetails.DakUserModified = (string)dakUserObj["modified"];
                    dakDetails.DakUserDakSubject = (string)dakUserObj["dak_subject"];
                    dakDetails.DakDecision = (string)dakUserObj["dak_decision"];
                    dakDetails.ArchivedDakUserId = (int)dakUserObj["archived_dak_user_id"];

                    var dakOriginObj = responseData["data"]["dak_origin"];
                    dakDetails.DakOriginId = (int)dakOriginObj["id"];
                    dakDetails.DocketingNo = (int)dakOriginObj["docketing_no"];
                    dakDetails.DakSubject = (string)dakOriginObj["dak_subject"];
                    dakDetails.DakTypeId = (int)dakOriginObj["dak_type_id"];
                    dakDetails.DakReceivedNo = (string)dakOriginObj["dak_received_no"];
                    dakDetails.DakSubject = (string)dakOriginObj["dak_subject"];
                    dakDetails.DakPriorityLevel = (string)dakOriginObj["dak_priority_level"];
                    dakDetails.DakSecurityLevel = (string)dakOriginObj["dak_security_level"];
                    dakDetails.NameEng = (string)dakOriginObj["name_eng"];
                    dakDetails.NameBng = (string)dakOriginObj["name_bng"];
                    dakDetails.SenderName = (string)dakOriginObj["sender_name"];
                    dakDetails.ReceiveDate = (string)dakOriginObj["receive_date"];
                    dakDetails.NothiMasterId = (int)dakOriginObj["nothi_master_id"];
                    dakDetails.DakStatus = (string)dakOriginObj["dak_status"];
                    dakDetails.UploaderDesignationId = (int)dakOriginObj["uploader_designation_id"];
                    dakDetails.ApplicationOrigin = (string)dakOriginObj["application_origin"];
                    dakDetails.DakOriginCreated = (string)dakOriginObj["created"];
                    dakDetails.DakOriginModified = (string)dakOriginObj["modified"];
                    dakDetails.SenderSarokNo = (string)dakOriginObj["sender_sarok_no"];
                    dakDetails.SenderOfficeId = (int)dakOriginObj["sender_office_id"];
                    dakDetails.SenderOfficerId = (int)dakOriginObj["sender_officer_id"];
                    dakDetails.SenderOfficeName = (string)dakOriginObj["sender_office_name"];
                    dakDetails.SenderOfficeUnitId = (int)dakOriginObj["sender_office_unit_id"];
                    dakDetails.SenderOfficeUnitName = (string)dakOriginObj["sender_office_unit_name"];
                    dakDetails.SenderOfficerDesignationId = (int)dakOriginObj["sender_officer_designation_id"];
                    dakDetails.SenderOfficerDesignationLabel = (string)dakOriginObj["sender_officer_designation_label"];
                    dakDetails.SendingDate = (string)dakOriginObj["sending_date"];
                    dakDetails.SenderAddress = (string)dakOriginObj["sender_address"];
                    dakDetails.SenderEmail = (string)dakOriginObj["sender_email"];
                    dakDetails.SenderPhone = (string)dakOriginObj["sender_phone"];
                    dakDetails.SenderMobile = (string)dakOriginObj["sender_mobile"];
                    dakDetails.DakSendingMedia = (string)dakOriginObj["dak_sending_media"];
                    dakDetails.ReceivingDate = (string)dakOriginObj["receiving_date"];
                    dakDetails.DakCover = (string)dakOriginObj["dak_cover"];
                    dakDetails.DakDescription = (string)dakOriginObj["dak_description"];
                    dakDetails.MetaData = (string)dakOriginObj["meta_data"];
                    dakDetails.ReceivingOfficeId = (int)dakOriginObj["receiving_office_id"];
                    dakDetails.ReceivingOfficeName = (string)dakOriginObj["receiving_office_name"];
                    dakDetails.ReceivingOfficeUnitId = (int)dakOriginObj["receiving_office_unit_id"];
                    dakDetails.ReceivingOfficeUnitName = (string)dakOriginObj["receiving_office_unit_name"];
                    dakDetails.ReceivingOfficerId = (int)dakOriginObj["receiving_officer_id"];
                    dakDetails.ReceivingOfficerDesignationId = (int)dakOriginObj["receiving_officer_designation_id"];
                    dakDetails.ReceivingOfficerDesignationLabel = (string)dakOriginObj["receiving_officer_designation_label"];
                    dakDetails.ReceivingOfficerName = (string)dakOriginObj["receiving_officer_name"];
                    dakDetails.DakOriginIsSummaryNothi = (int)dakOriginObj["is_summary_nothi"];
                    dakDetails.PreviousReceiptNo = (string)dakOriginObj["previous_receipt_no"];
                    dakDetails.PreviousDocketingNo = (string)dakOriginObj["previous_docketing_no"];
                    dakDetails.IsRollbackToDak = (int)dakOriginObj["is_rollback_to_dak"];
                    dakDetails.DakOriginFromPotrojari = (int)dakOriginObj["from_potrojari"];

                    
                    var movementObj = responseData["data"]["movement_status"].Value<JObject>();
                    var movementData = movementObj.ToObject<MovementStatus>();

                    dakDetails.MovementStatus = movementData;
                    dakDetails.AttachmentCount=(int)responseData["data"]["attachment_count"];



                    //var clientArray = responseData["data"].Value<JArray>();
                    //var clients = clientArray.ToObject<List<DakAttachment>>();
                    //attachmentVm.Records = clients;
                    //attachmentVm.Status = (string)responseData["status"];
                }
            }
            return dakDetails;
        }
    }
}
