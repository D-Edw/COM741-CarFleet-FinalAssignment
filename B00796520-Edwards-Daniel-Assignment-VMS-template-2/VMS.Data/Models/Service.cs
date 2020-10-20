using System;
using System.ComponentModel.DataAnnotations;

namespace VMS.Data.Models
{
    public class Service
    { 
        //service attributes
        [Key]
        public int Id {get; set;}
        [Required]
        public String ServiceName {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime DateOfService {get; set;}
        [Required]
        public String WorkDone {get; set;}
        [Required]
        public int Mileage {get; set;}
        [Required]
        public double ServiceCost {get; set;}   

        //Foreign key relating to Vehicle
        public int VehicleID {get; set;}

        //Navigation property to navigate to the vehicle
        public Vehicle Vehicle {get; set;} 
        
    }
}