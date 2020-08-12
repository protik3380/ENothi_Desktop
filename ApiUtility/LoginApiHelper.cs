using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ENothi_Desktop.Models;

namespace ENothi_Desktop.ApiUtility
{
    public static class LoginApiHelper
    {
        public static LoginResponse ValidateUser(LoginCredential loginCredential,string deviceId,string machineName)
        {
             LoginResponse user = null;

            using (var client = new HttpClientDemo())
            {

                client.DefaultRequestHeaders.Add("device-id", deviceId);
                client.DefaultRequestHeaders.Add("device-type", machineName);

                var postTask = client.PostAsJsonAsync("api/login", loginCredential);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsAsync<LoginResponse>().Result;
                    user = data;
                }
            }
            return user;
        }
    }
}
