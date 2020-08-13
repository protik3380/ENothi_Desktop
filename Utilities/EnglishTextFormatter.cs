using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENothi_Desktop.Utilities
{
    public class EnglishTextFormatter
    {
        public static String ConvertToEnglish(String value)
        {
            value = value.Replace("১", "1");
            value = value.Replace("২", "2");
            value = value.Replace("৩", "3");
            value = value.Replace("৪", "4");
            value = value.Replace("৫", "5");
            value = value.Replace("৬", "6");
            value = value.Replace("৭", "7");
            value = value.Replace("৮", "8");
            value = value.Replace("৯", "9");
            value = value.Replace("০", "0");
            return value;
        }

    }
}
