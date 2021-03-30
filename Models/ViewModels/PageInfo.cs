using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingApp.Models.ViewModels
{
    //The PageInfo class contains an ItemsPerPage integer, a CurrentPage integer, a TotalItems integer, and a NumOfPages integer
    public class PageInfo
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int NumOfPages => (int) (Math.Ceiling((decimal) TotalItems / ItemsPerPage));
    }
}
