using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENothi_Desktop.Utilities
{
    public class BengaliTextFormatter
    {
        public static String ConvertToBengali(String value)
        {
            value = value.Replace("1", "১");
            value = value.Replace("2", "২");
            value = value.Replace("3", "৩");
            value = value.Replace("4", "৪");
            value = value.Replace("5", "৫");
            value = value.Replace("6", "৬");
            value = value.Replace("7", "৭");
            value = value.Replace("8", "৮");
            value = value.Replace("9", "৯");
            value = value.Replace("0", "০");
            return value;
        }
    }
}
