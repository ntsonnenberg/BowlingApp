using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingApp.Models.ViewModels
{
    public class PageInfo
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int NumOfPages => (int) (Math.Ceiling((decimal) TotalItems / ItemsPerPage));
    }
}
