using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models
{
   public class UserEmployeeOfficeVm
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("employee_info")]
        public EmployeeInfo EmployeeInfo { get; set; }

        [JsonProperty("office_info")]
        public List<OfficeInfo> OfficeInfo { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
