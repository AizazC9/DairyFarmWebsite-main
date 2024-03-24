using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DairyFarm.Models;
using DairyFarm.Models.Domain;
using DairyFarm.Data;
using Microsoft.EntityFrameworkCore;

namespace DairyFarm.Controllers
{
  
    public class MaintainDietController : Controller
    {
       
        private readonly ApplicationContextDB DBcontext;
        public MaintainDietController(ApplicationContextDB context)
        {
            this.DBcontext = context;
        }

    
        [HttpGet]
        public async Task<IActionResult> MaintainDiet()
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