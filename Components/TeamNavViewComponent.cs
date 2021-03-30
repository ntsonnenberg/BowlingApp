using BowlingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingApp.Components
{
    public class TeamNavViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;

        public TeamNavViewComponent(BowlingLeagueContext con)
        {
            context = con;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            return View(context.Teams
                .Distinct()
                .OrderBy(t => t));
        }
    }
}
