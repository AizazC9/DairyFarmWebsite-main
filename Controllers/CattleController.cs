using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DairyFarm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DairyFarm.Models.Domain;
using Microsoft.Extensions.Logging;

namespace DairyFarm.Controllers
{
    public class CattleController : Controller
    {

        private readonly ApplicationContextDB DBcontext;
        public CattleController(ApplicationContextDB context)
        {
            this.DBcontext = context;
        }

    
        [HttpGet]
        public async Task<IActionResult> Cattle()
        {
            var cattle = await DBcontext.Cattles.ToListAsync();
            return View(cattle);
        }

 public async Task<IActionResult> Index()
        {
            var cattle = await DBcontext.Cattles.ToListAsync();
            return View(cattle);
}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}