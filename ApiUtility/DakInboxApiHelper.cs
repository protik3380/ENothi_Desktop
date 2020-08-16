using System.Net.Http;
using System.Net.Http.Headers;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Models;
using ENothi_Desktop.Models.DakInbox;

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
                    data = result.Content.ReadAsAsync<DakInbox>().Result;
                }
            }
            return data;
        }
    }
}
