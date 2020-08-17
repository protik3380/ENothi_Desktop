using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENothi_Desktop.Utilities
{
    public class PriorityLevelGenerator
    {
        public static String GeneratePriorityLevel(String code)
        {
            String securityLevel = "";

            switch (code)
            {
                case "4":
                    securityLevel = "জরুরি";
                    break;
                case "5":
                    securityLevel = "অবিলম্বে";
                    break;
                case "6":
                    securityLevel = "সর্বোচ্চ অগ্রাধিকার";
                    break;
                case "3":
                    securityLevel = "তাগিদপত্র";
                    break;
                case "2":
                    securityLevel = "দৃষ্টি আকর্ষণ";
                    break;
            }
            return securityLevel;
        }
    }
}


//"6": "সর্বোচ্চ অগ্রাধিকার",
//"5": "অবিলম্বে",
//"4": "জরুরি",
//"3": "তাগিদপত্র",
//"2": "দৃষ্টি আকর্ষণ"