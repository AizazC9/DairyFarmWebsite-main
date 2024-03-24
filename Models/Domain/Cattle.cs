using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyFarm.Models.Domain
{
    public class Cattle
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string? Tag { get; set; }
    public int Age { get; set; }
    public int DailyMilk { get; set; }
    public string? Examination{get; set;}
    public string? Medication{get; set;}
    public string? Insemination{get; set;}
public  string? DietPlan{get; set;}
public int Price{get; set;}
public float Weight{get; set;}
public float Temperature{get; set;}
public int Abortion{get; set;}
public int NormalDelivery{get; set;}
public string? Diseases{get; set;}
public DateTime Date{get; set;}
    }

}
