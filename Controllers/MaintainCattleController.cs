using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DairyFarm.Data;
using DairyFarm.Models;
using DairyFarm.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DairyFarm.Controllers
{
 
    public class MaintainCattleController : Controller
    {
        
private readonly ApplicationContextDB DBcontext;
        public MaintainCattleController(ApplicationContextDB context)
        {
            this.DBcontext = context;
        }
        public IActionResult MaintainCattle()
        {
            return View();
        }

[HttpGet]
        public IActionResult Add()
        {
            return View();
        }


[HttpGet]
public async Task<IActionResult> Update(int Id)
{
    var cattle = await DBcontext.Cattles.FirstOrDefaultAsync(c => c.Id == Id);
    if (cattle != null)
    {
        var UpdateModel = new UpdatedCattle()
        {
            Id = cattle.Id,
            Tag = cattle.Tag,
            Age = cattle.Age,
            DailyMilk = cattle.DailyMilk,
            Weight = cattle.Weight,
            Examination = cattle.Examination,
            Medication = cattle.Medication,
            Insemination = cattle.Insemination,
            DietPlan = cattle.DietPlan,
            Price = cattle.Price,
            Temperature = cattle.Temperature,
            Abortion = cattle.Abortion,
            NormalDelivery = cattle.NormalDelivery,
            Diseases = cattle.Diseases,
            Date = cattle.Date
        };
        return await Task.Run(() => View("Update", UpdateModel));
    }
    return RedirectToAction("Cattle");
}

[HttpPost]
public async Task<IActionResult> Update(UpdatedCattle UpdatedCattleDataTODb)
{
    var cattle = await DBcontext.Cattles.FindAsync(UpdatedCattleDataTODb.Id);
    if (cattle != null)
    {
        cattle.Id = UpdatedCattleDataTODb.Id;
        cattle.Tag = UpdatedCattleDataTODb.Tag;
        cattle.Age = UpdatedCattleDataTODb.Age;
        cattle.DailyMilk = UpdatedCattleDataTODb.DailyMilk;
        cattle.Weight = UpdatedCattleDataTODb.Weight;
        cattle.Examination = UpdatedCattleDataTODb.Examination;
        cattle.Medication = UpdatedCattleDataTODb.Medication;
        cattle.Insemination = UpdatedCattleDataTODb.Insemination;
        cattle.DietPlan = UpdatedCattleDataTODb.DietPlan;
        cattle.Price = UpdatedCattleDataTODb.Price;
        cattle.Temperature = UpdatedCattleDataTODb.Temperature;
        cattle.Abortion = UpdatedCattleDataTODb.Abortion;
        cattle.NormalDelivery = UpdatedCattleDataTODb.NormalDelivery;
        cattle.Diseases = UpdatedCattleDataTODb.Diseases;
        cattle.Date = UpdatedCattleDataTODb.Date;
        await DBcontext.SaveChangesAsync();
        return RedirectToAction("Cattle", "Cattle");
    }

    return RedirectToAction("Cattle", "Cattle");
}

[HttpPost]
        public async Task<IActionResult> Add(AddCattle AddCattleDataTODb)
        {
            var cattle = new Cattle()
            {
                Tag = AddCattleDataTODb.Tag,
                Age = AddCattleDataTODb.Age,
                DailyMilk = AddCattleDataTODb.DailyMilk,
                Weight = AddCattleDataTODb.Weight,
                Examination = AddCattleDataTODb.Examination,
                Medication = AddCattleDataTODb.Medication,
                Insemination = AddCattleDataTODb.Insemination,
                DietPlan = AddCattleDataTODb.DietPlan,
                Price = AddCattleDataTODb.Price,
                Temperature = AddCattleDataTODb.Temperature,
                Abortion = AddCattleDataTODb.Abortion,
                NormalDelivery = AddCattleDataTODb.NormalDelivery,
                Diseases = AddCattleDataTODb.Diseases,
                Date = AddCattleDataTODb.Date
            };
            await DBcontext.Cattles.AddAsync(cattle);   
            await DBcontext.SaveChangesAsync();        
            return RedirectToAction("Cattle", "Cattle");
        }

         public IActionResult Update()
        {
            return View();
        }

        public async Task<IActionResult> Delete(UpdatedCattle model)
        {
            var cattle = await DBcontext.Cattles.FindAsync(model.Id);
            if (cattle != null)
            {
                DBcontext.Cattles.Remove(cattle);
                await DBcontext.SaveChangesAsync();
                return RedirectToAction("Cattle", "Cattle");
            }
            return RedirectToAction("Cattle", "Cattle");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}