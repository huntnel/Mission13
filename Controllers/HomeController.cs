using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{

    // https://www.pluralsight.com/guides/asp-net-mvc-populating-dropdown-lists-in-razor-views-using-the-mvvm-design-pattern-entity-framework-and-ajax
    public class HomeController : Controller
    {
        private IBowlersRepository repo;
        private ITeamsRepository Trepo;
        private IBowlersRepository _context { get; set; }

        public HomeController(IBowlersRepository temp, ITeamsRepository tem)
        {
            repo = temp;
            Trepo = tem;
        }

        public IActionResult Index(string team)
        {
            ViewBag.SelectedTeam = team;
            var blah = repo.Bowlers.Where(x => x.Team.TeamName == team || team == null).Include(x => x.Team).ToList();
            return View(blah);
        }


        [HttpGet]
        public IActionResult Edit(int bowlerId)
        {
            Bowler b = repo.Bowlers.Include(x => x.Team).Single(x => x.BowlerID == bowlerId);
            return View(b);
        }


        [HttpPost]
        public IActionResult Edit(Bowler bowler)
        {
            if(ModelState.IsValid)
            {
                repo.SaveBowler(bowler);
            }
            
            var blah = repo.Bowlers.Include(x => x.Team).ToList();
            
            return View("Index", blah);
        }

        [HttpGet]
        public IActionResult Delete(int bowlerId)
        {
            Bowler b = repo.Bowlers.Single(x => x.BowlerID == bowlerId);
            if (ModelState.IsValid)
            {
                repo.DeleteBowler(b);
            }
            
            var blah = repo.Bowlers.Include(x => x.Team).ToList();
            return View("Index", blah);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        


        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            if (ModelState.IsValid)

            {
                repo.CreateBowler(b);
                repo.SaveBowler(b);
                return View("Index", b);
            }
            else
            {
                return View(b);
            }
        }

    }
}
