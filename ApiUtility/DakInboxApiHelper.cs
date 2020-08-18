using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ENothi_Desktop.ApiUtility
{
    public static class DakInboxApiHelper
    {
        public static ModulePendingCount GetModulePendingCount(ModuleCountDto requestDto)
        {
            ModulePendingCount modulePendingCount = new ModulePendingCount();

            using (var client = new HttpClientDemo())
            {
                client.DefaultRequestHeaders.Add("api-version", "2");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ParameterHelper.Token);

                var postTask = client.PostAsJsonAsync("/api/module/pending", requestDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsAsync<dynamic>().Result;
                    var designationWiseData = data["data"]["designation"];
                    if (designationWiseData != null)
                    {
                        var model = designationWiseData[requestDto.DesignationId.ToString()];
                        modulePendingCount.DesignationWiseDakNo = model["dak"];
                        modulePendingCount.DesignationWiseOwnOfficeNothiNo = model["own_office_nothi"];
                        modulePendingCount.DesignationWiseOtherOfficeNothiNo = model["other_office_nothi"];
                        var totalModel = data["data"]["total"];
                        modulePendingCount.TotalDakNo = totalModel["dak"];
                        modulePendingCount.TotalOwnOfficeNothiNo = totalModel["own_office_nothi"];
                        modulePendingCount.TotalOtherOfficeNothiNo = totalModel["other_office_nothi"];
                    }
                    else
                    {
                        modulePendingCount = null;
                    }
                }
                else
                {
                    modulePendingCount = null;
                }
            }
            return modulePendingCount;
        }


        public static DakInbox GetDakInboxData(DakInboxDto requestDto)
        {
            DakInbox data = null;
            using (var client = new HttpClientDemo())
            {
                client.DefaultRequestHeaders.Add("api-version", "2");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ParameterHelper.Token);

                var postTask = client.PostAsJsonAsync("/api/dak/inbox", requestDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // var d = result.Content.ReadAsAsync<dynamic>().Result;
                    data = result.Content.ReadAsAsync<DakInbox>().Result;
                }
            }
            return data;
        }

        public static MovementStatusVm GetDakMovementStatusByDakId(DakMovementDto request)
        {
            MovementStatusVm movementStatusVm = new MovementStatusVm();
            using (var client = new HttpClientDemo())
            {
                client.DefaultRequestHeaders.Add("api-version", "1");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ParameterHelper.Token);

                var postTask = client.PostAsJsonAsync("/api/dak/movements", request);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    JObject responseData = JObject.Parse(data);
                    var clientArray = responseData["data"]["records"].Value<JArray>();
                    var clients = clientArray.ToObject<List<MovementStatus>>();

                    movementStatusVm.Records = clients;
                    movementStatusVm.TotalRecords = (int)responseData["data"]["total_records"];

                    //var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    //JObject result = JObject.Parse(responseData);
                    //var clientarray = result["items"].Value<JArray>();
                    //List<Client> clients = clientarray.ToObject<List<Client>>();
                }
            }
            return movementStatusVm;
        }



        public static DakInbox GetArchiveDakListData(DakInboxDto requestDto)
        {
            DakInbox data = null;
            using (var client = new HttpClientDemo())
            {
                client.DefaultRequestHeaders.Add("api-version", "2");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ParameterHelper.Token);

                var postTask = client.PostAsJsonAsync("/api/dak/onulipi", requestDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // var d = result.Content.ReadAsAsync<dynamic>().Result;
                    data = result.Content.ReadAsAsync<DakInbox>().Result;
                }
            }
            return data;
        }
    }
}
