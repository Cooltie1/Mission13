using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingRepository _repo { get; set; }


        public HomeController(IBowlingRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string team = "")
        {
            ViewBag.selected = team;
            var teams = _repo.teams;
            ViewBag.teams = teams;
            if (team == "")
            {
                
                
                var bowlersTmp = _repo.bowlers;
                // .inlude(x => team) watch 05 video for help
                return View(bowlersTmp);
            }
            
            var bowlers = _repo.bowlers.Where(b => b.Team.TeamName == team);
            return View(bowlers);
            
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

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.teams = _repo.teams;
            var bowler = _repo.bowlers.Single(x => x.BowlerID == bowlerid);
            return View("AddBowler", bowler);
        }
        [HttpPost]
        public IActionResult Edit (Bowler bowler)
        {
            _repo.SaveBowler(bowler);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int bowlerid)
        {
           Bowler bowler =  _repo.bowlers.Single(x => x.BowlerID == bowlerid);
            _repo.DeleteBowler(bowler);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.teams = _repo.teams;
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveBowler(bowler);
                return RedirectToAction("Index");
            }
            ViewBag.teams = _repo.teams;
            return View("AddBowler");
        }
    }
}
