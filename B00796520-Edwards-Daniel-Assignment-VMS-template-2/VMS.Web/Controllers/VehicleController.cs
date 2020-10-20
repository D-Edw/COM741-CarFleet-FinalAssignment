using System;
using VMS.Data.Models;
using VMS.Data.Services;
using VMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace VMS.Web.Controllers
{

 public class VehicleController : BaseController
    {
       private readonly VehicleDbService svc;
        public VehicleController()
        {
            svc = new VehicleDbService();
        }

        // GET /vehicle/index
        //public IActionResult Index()
        //{
            //var vehicles = svc.GetAllVehicles();
            //return View(vehicles);
        //}

        // GET /vehicle/index
        public ActionResult Index(string sortOrder)
        {
            ViewBag.MakeSortParm = sortOrder == "Make" ? "make_desc" : "Make";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FuelSortParm = sortOrder == "Fuel" ? "fuel_desc" : "Fuel";

            var vehicles = svc.GetAllVehicles();
            
            switch (sortOrder)
            {
                case "Make":
                    vehicles = vehicles.OrderBy(v => v.Make).ToList();
                    break;
                case "make_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Make).ToList();
                    break;
                case "Date":
                    vehicles = vehicles.OrderBy(v => v.DateOfReg).ToList();
                    break;
                case "date_desc":
                    vehicles = vehicles.OrderByDescending(v => v.DateOfReg).ToList();
                    break;
                case "Fuel":
                    vehicles = vehicles.OrderBy(v => v.Fuel).ToList();
                    break;
                case "fuel_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Fuel).ToList();
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.Id).ToList();
                    break;
            }
                return View(vehicles.ToList());
        }

        // GET /vehicle/details/{id}
        public IActionResult Details(int id)
        {
            var vehicle = svc.GetVehicleById(id);
            if (vehicle == null)
            {
                Alert("Vehicle not found!", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        // GET /vehicle/create
        public IActionResult Create()
        {
            // render blank form
            return View();
        }

        // POST /vehicle/createVehicle
        [HttpPost]
        public IActionResult Create(Vehicle v)
        {
            
            if(ModelState.IsValid)
            {
                svc.AddVehicle(v.Make, v.Model, v.Reg, v.Colour, v.DateOfReg, v.Transmission, v.CO2Rating, v.Fuel, v.BodyType, v.NoOfDoors, v.ImageUrl);
                Alert("Vehicle successfully added!", AlertType.success);
                return RedirectToAction(nameof(Index));
            }

            return View(v);
        }

        // GET /vehicle/edit/{id}
        public IActionResult Edit(int id)
        {
          
            var vehicle = svc.GetVehicleById(id);
      
            if (vehicle == null)
            {
                Alert("Vehicle not found!", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            
            return View(vehicle);
        }

        // POST /vehicle/edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, Vehicle v)
        {
            if(ModelState.IsValid)
            {
            svc.UpdateVehicle(id, v);
            Alert("Vehicle successfully edited!", AlertType.info);
            return RedirectToAction(nameof(Index));
            }

            return View(v);
        }

        // GET /vehicle/delete/{id}
        public IActionResult Delete(int id)
        {
            
            var vehicle = svc.GetVehicleById(id);
            if (vehicle == null)
            {
                Alert("Vehicle not found!", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        // POST /vehicle/delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            
           svc.DeleteVehicle(id);
           Alert("Vehicle successfully deleted!", AlertType.success);
         
            
            return RedirectToAction(nameof(Index));
        }

        // GET /vehicle/create service/{id}
        public IActionResult CreateService(int id)
        {
            var vehicle = svc.GetVehicleById(id);

            if (vehicle == null)
            {
                Alert("Vehicle not found!", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

            var svm = new ServiceViewModel
            {
               VehicleId = vehicle.Id 
            };

            return View(svm);
        }

        //POST /vehicle/create service/{svm}
        [HttpPost]

        public IActionResult CreateService(ServiceViewModel s)
        {
            if (ModelState.IsValid)
            {
                svc.AddService(s.VehicleId,s.ServiceName,s.DateOfService,s.WorkDone,s.Mileage,s.ServiceCost);
                Alert("Service successfully created!", AlertType.success);

                return RedirectToAction(nameof(Details), new {id = s.VehicleId});
            }

            return View(s);
        }

         // GET /vehicle/delete service/{id}
        public IActionResult DeleteService(int id)
        {
            var service = svc.GetServiceById(id);

            if (service == null)
            {
                Alert("Vehicle not found!", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }

             var svm = new ServiceViewModel
            {
               Id = service.Id, 
               ServiceName = service.ServiceName,
               DateOfService = service.DateOfService,
               ServiceCost = service.ServiceCost,
               Mileage = service.Mileage,
               WorkDone = service.WorkDone,
               VehicleId = service.VehicleID

            };

            return View(svm);
        }

        //POST /vehicle/delete service/{svm}
        [HttpPost]
        public IActionResult DeleteServiceConfirm(int id, int vehicleId)
        {
            svc.DeleteService(id);
            Alert("Service successfully deleted!", AlertType.success);

            return RedirectToAction(nameof(Details), new {Id = vehicleId});
            
        }

  
        
    }
}