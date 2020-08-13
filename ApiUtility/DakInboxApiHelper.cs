using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Dto.RequestDto;
using ENothi_Desktop.Models;

namespace ENothi_Desktop.ApiUtility
{
    public static class DakInboxApiHelper
    {
        public static ModulePendingCount GetModulePendingCount(string token, ModuleCountDto requestDto)
        {
            ModulePendingCount modulePendingCount=new ModulePendingCount();

            using (var client = new HttpClientDemo())
            {
                client.DefaultRequestHeaders.Add("api-version", "2");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var postTask = client.PostAsJsonAsync("/api/module/pending", requestDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                   var data = result.Content.ReadAsAsync<dynamic>().Result;
                   var designationWiseData = data["data"]["designation"];
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
            return modulePendingCount;
        }
    }
}
