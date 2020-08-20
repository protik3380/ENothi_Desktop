using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENothi_Desktop.Models
{
    public class Page
    {
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int FromIndex { get; set; }
        public int ToIndex { get; set; }
    }
}
