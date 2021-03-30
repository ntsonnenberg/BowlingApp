using BowlingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingApp.Components
{
    /**
     * This is the Team Navigation vew component class
     * This class has a private bowling league context that gets initialized in the constructor
     * It has an invoke method, which returns the bowling teams in the database, this will get passed to the controller to display and filter the view by team
     */
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
