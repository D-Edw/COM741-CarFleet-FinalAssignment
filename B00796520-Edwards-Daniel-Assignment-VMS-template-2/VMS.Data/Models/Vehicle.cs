using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace VMS.Data.Models
{      
    public class Vehicle
    {
        public Vehicle ()
        {
            //initialise the Vehicle Service list relationship
            Services = new List<Service>();
        }
       
       //vehicle attributes, Id used as primary key
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
       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
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
       [Required]
       public string ImageUrl {get; set;}

       //navigation properties
       public IList<Service> Services {get; set;}

       //ToString method for printing Vehicles to console during testing
       public override string ToString()
       {
           return $"Id:{Id} Make:{Make} Model:{Model} Registration Number:{Reg} Colour:{Colour} Date Of Registration:{DateOfReg} Age Of Vehicle:{AgeOfVehicle} Transmission Type:{Transmission} CO2 Rating:{CO2Rating} Fuel Type:{Fuel} Body Type:{BodyType} Number Of Doors:{NoOfDoors}";
       }
    }
}