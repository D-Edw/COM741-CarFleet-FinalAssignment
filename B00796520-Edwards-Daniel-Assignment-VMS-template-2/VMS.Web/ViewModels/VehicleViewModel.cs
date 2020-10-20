using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VMS.Web.ViewModels
{
    public class VehicleViewModel
    {
        [Key]
       public int Id {get; set;}
       [Required]
       public String Make {get; set;}
       [Required]
       public String Model {get; set;}
       [Required]
       public String Reg {get; set;}
       [Required]
       public String Colour {get; set;}
       
       [Required]
       //[DataType(DataType.Date)]
       //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
       public DateTime DateOfReg {get; set;}
       public int AgeOfVehicle => (DateTime.Now - DateOfReg).Days/365;
       [Required]
       public String Transmission {get; set;}
       [Required]
       
       public int CO2Rating {get; set;}
       [Required]
       public String Fuel {get; set;}
       [Required]
       public String BodyType {get; set;}
       [Required]
       public int NoOfDoors {get; set;}
       
    }
}