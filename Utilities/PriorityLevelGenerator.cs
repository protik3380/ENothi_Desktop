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
                case "2":
                    securityLevel = "জরুরি";
                    break;
                case "3":
                    securityLevel = "অবিলম্বে";
                    break;
                case "4":
                    securityLevel = "সর্বোচ্চ অগ্রাধিকার";
                    break;
                case "5":
                    securityLevel = "তাগিদপত্র";
                    break;
                case "6":
                    securityLevel = "দৃষ্টি আকর্ষণ";
                    break;
            }
            return securityLevel;
        }
    }
}
