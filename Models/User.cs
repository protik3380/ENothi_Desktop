using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models
{
   public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("user_alias")]
        public string UserAlias { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("employee_record_id")]
        public int EmployeeRecordId { get; set; }
    }
}
