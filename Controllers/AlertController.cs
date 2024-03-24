using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DairyFarm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DairyFarm.Controllers
{
 
    public class AlertController : Controller
    {

         private readonly ApplicationContextDB DBcontext;
        public AlertController(ApplicationContextDB context)
        {
            this.DBcontext = context;
        }

    
        [HttpGet]
        public async Task<IActionResult> Alert()
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