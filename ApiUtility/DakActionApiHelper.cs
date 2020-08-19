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
using Newtonsoft.Json.Linq;

namespace ENothi_Desktop.ApiUtility
{
    public static class DakActionApiHelper
    {
        public static bool DakArchive(DakActionArchiveDto request)
        {
           // DakAttachmentVm attachmentVm = new DakAttachmentVm();
           bool isArchive = false;
            using (var client = new HttpClientDemo())
            {
                client.DefaultRequestHeaders.Add("api-version", "1");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ParameterHelper.Token);

                var postTask = client.PostAsJsonAsync("/api/dak/action/archive", request);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    isArchive = data.Contains(@"ডাকটি সফলভাবে আর্কাইভ করা হয়েছে ");
                }
            }
            return isArchive;
        }
    }
}
