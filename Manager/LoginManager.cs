using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENothi_Desktop.Models.Interface.IManager;

namespace ENothi_Desktop.Manager
{
    public class LoginManager : ILoginManager
    {
        public string AutoCompleteUserId(string userId)
        {
            string newUserId = String.Empty;
            if (userId != "" && userId.Length < 12)
            {
                int numOfZero = 12 - userId.Length;
                string userIdFirstPart = userId.Substring(0, 1);
                string userIdLastPart = userId.Substring(1, userId.Length - 1);
                string userIdMiddlePart = String.Empty;
                for (int i = 0; i < numOfZero; i++)
                {
                    userIdMiddlePart += "0";
                }
                 newUserId = userIdFirstPart + userIdMiddlePart + userIdLastPart;         
            }
            return newUserId;
        }
    }
}
