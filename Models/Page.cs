using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENothi_Desktop.Models
{
    public class Page
    {
        public decimal TotalRecords { get; set; }
        public decimal PageSize { get; set; }
        //public int PageCount { get; set; }
        public decimal CurrentPage { get; set; }
        public decimal FromIndex { get; set; }
        public decimal ToIndex { get; set; }

        public decimal PageCount
        {
            get
            {

                decimal pageCount = 0;
                if (TotalRecords > 0)
                {
                    pageCount = Math.Ceiling(TotalRecords / PageSize);
                }
                return pageCount;
            }
        }



        public Page()
        {
            TotalRecords = 0;
            CurrentPage = 1;
            PageSize = 10;
            //PageCount = 0;
            FromIndex = 0;
            ToIndex = 0;
        }
    }
}
