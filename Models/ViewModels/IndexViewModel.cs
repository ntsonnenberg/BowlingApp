using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingApp.Models.ViewModels
{
    //The IndexViewModel class contains a list of Bowlers, a PageInfo object, and a TeamName string
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageInfo PageInfo { get; set; }
        public string TeamName { get; set; }
    }
}
