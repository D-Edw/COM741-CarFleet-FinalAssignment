using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VMS.Web.ViewModels
{
    public class ServiceViewModel
    {
        // selectlist of Vehicles (id, make, model)    
        public SelectList Vehicles { set; get; }

        // Collecting VehicleId and Service Details in Form

        [Required]
        [Display(Name = "Select Vehicle")]
        [Key]
        public int Id;
        public int VehicleId { get; set; }
        [Required]
        [Display(Name = "Who is carrying out the service?")]
        public string ServiceName {get; set;}

       [Required]
       [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
       public System.DateTime DateOfService {get; set;}

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string WorkDone { get; set; }
        [Required]
        public int Mileage {get; set;}
        [Required]
        public double ServiceCost {get; set;}   
    }

}