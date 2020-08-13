using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENothi_Desktop.Utilities
{
    public class SecurityLevelGenerator
    {
        public static String GenerateSecurityLevel(String code)
        {
            String securityLevel = "";

            if (code == null)
                return "";

            switch (code)
            {
                case "2":
                    securityLevel = "অতি গোপনীয়";
                    break;
                case "3":
                    securityLevel = "বিশেষ গোপনীয়";
                    break;
                case "4":
                    securityLevel = "গোপনীয়";
                    break;
                case "5":
                    securityLevel = "সীমিত";
                    break;
            }

            return securityLevel;
        }
    }
}
