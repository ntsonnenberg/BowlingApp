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

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext con)
        {
            _logger = logger;
            context = con;
        }

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
