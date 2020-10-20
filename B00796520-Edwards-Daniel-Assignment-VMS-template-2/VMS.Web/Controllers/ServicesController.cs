using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VMS.Web.ViewModels;
using VMS.Data.Models;
using VMS.Data.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VMS.Web.Controllers
{
    public class ServicesController : BaseController
    {

        private readonly VehicleDbService svc;
        public ServicesController()
        {
            svc = new VehicleDbService();
        }

        // GET /services/index
        public IActionResult Index()
        {
            var services = svc.GetAllServices();
            return View(services);
        }

        // GET /services/create
        public IActionResult Create()
        {
            var vehicles = svc.GetAllVehicles();
            var svm = new ServiceViewModel {
                Vehicles = new SelectList(vehicles, "Id", "Reg") 
            };
            
            // render blank form
            return View( svm );
        }

        // POST /services/create
        [HttpPost]
        public IActionResult Create(ServiceViewModel svm)
        {
            if (ModelState.IsValid)
            {
                svc.AddService(svm.VehicleId, svm.ServiceName, svm.DateOfService, svm.WorkDone, svm.Mileage, svm.ServiceCost);
                Alert("Service successfully created!", AlertType.success);

                return RedirectToAction(nameof(Index));
            }
            // redisplay the form for editing
            return View(svm);
        }

            // GET /Service/Details/{id}
        public IActionResult Details(int id)
        {
          
            var service = svc.GetServiceById(id);
      
            if (service == null)
            {
                Alert("Service not found!", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            
            return View(service);
        }

        
    }
}