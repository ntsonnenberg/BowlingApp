using BowlingApp.Models;
using BowlingApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context;

        public int ItemsPerPage = 5;

        //initializes a bowling league context
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext con)
        {
            _logger = logger;
            context = con;
        }

        /**
         * This is the Index method (parameters include the team id number, team name and current page number set to 1)
         * A new index view model gets initialize in the method
         * The view model contacts a list of bowlers, a PageInfo object (for navigation), and TeamName string
         * Passes all the view model data to the index view to be used in the web page
         */
        public IActionResult Index(long? teamid, string teamName, int pageNum = 1)
        {
            IndexViewModel IndexInfo = new IndexViewModel
            {
                Bowlers = context.Bowlers
                    .Where(t => t.TeamId == teamid || teamid == null)
                    .OrderBy(b => b.BowlerLastName)
                    .Skip((pageNum - 1) * ItemsPerPage)
                    .Take(ItemsPerPage)
                    .ToList(),

                PageInfo = new PageInfo
                {
                    ItemsPerPage = ItemsPerPage,
                    CurrentPage = pageNum,
                    TotalItems = (teamName == null ? context.Bowlers.Count() : context.Bowlers.Where(t => t.TeamId == teamid).Count())
                },

                TeamName = teamName
            };

            return View(IndexInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
