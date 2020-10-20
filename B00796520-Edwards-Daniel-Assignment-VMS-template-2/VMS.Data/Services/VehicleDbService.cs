using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using VMS.Data.Models;
using VMS.Data.Repositories;

namespace VMS.Data.Services
{
    // implement each of these methods (removing the throw statements)
    public class VehicleDbService : IVehicleService
    {
        private readonly VehicleDbContext db;

        public VehicleDbService()
        {
            db = new VehicleDbContext();
        }//VehicleDbService

        public void Initialise()
        {
            db.Initialise();
        }//Initialise
       
        // -----------------Vehicle Management Operations---------------------------
         public IList<Vehicle> GetAllVehicles()
        {
                    return db.Vehicles
                    .ToList();
                
                
        }//GetAllVehicles
        public Vehicle AddVehicle(String make, String model, String reg, String colour, DateTime dateOfReg, String transmission, int co2rating, String fuel, String bodyType, int noOfDoors, String imageUrl)
        {
           //verify that a vehicle with the same Reg does not exist
           var exists = db.Vehicles.FirstOrDefault(o => o.Reg == reg);
           if (exists != null)
           {
               return null;
           } 
            
            var v = new Vehicle
            {
                Make = make,
                Model = model,
                Reg = reg,
                Colour = colour,
                DateOfReg = dateOfReg,
                Transmission = transmission,
                CO2Rating = co2rating,
                Fuel = fuel,
                BodyType = bodyType,
                NoOfDoors = noOfDoors,
                ImageUrl = imageUrl
            };

            //add new vehicle, save changes and return newly added vehicle
            db.Vehicles.Add(v);
            db.SaveChanges();
            return v;
        }//AddVehicle

        public bool DeleteVehicle(int id)
        {
            var v = GetVehicleById(id);
            if ( v == null)
            {
                return false;
            }
            db.Vehicles.Remove(v);
            db.SaveChanges();
            return true;
        }//DeleteVehicle
  
        public Vehicle GetVehicleById(int id)
        {
            return db.Vehicles.Include(v => v.Services)
                                .FirstOrDefault(v => v.Id == id);
        }//GetVehicleById
        public Vehicle UpdateVehicle(int id, Vehicle updated)
        {
            //verify the vehicle exists
            var vehicle = GetVehicleById(id);

            if( vehicle == null)
            {
                return null;
            }
            //update the details of the vehicle retrieved and save
            vehicle.Make = updated.Make;
            vehicle.Model = updated.Model;
            vehicle.Reg = updated.Reg;
            vehicle.Colour = updated.Colour;
            vehicle.DateOfReg = updated.DateOfReg;
            vehicle.Transmission = updated.Transmission;
            vehicle.CO2Rating = updated.CO2Rating;
            vehicle.Fuel = updated.Fuel;
            vehicle.BodyType = updated.BodyType;
            vehicle.NoOfDoors = updated.NoOfDoors;
            vehicle.ImageUrl = updated.ImageUrl;

            db.SaveChanges();
            return vehicle;

        }//UpdateVehicle


        // Service Management
        public Service AddService(int vehicleID, String serviceName, DateTime dateOfService, String workDone, int mileage, double serviceCost)
        {
            // verify vehicle
            var v = GetVehicleById(vehicleID);
            if (v == null)
            {
                return null;
            }
            var s = new Service
            {
                VehicleID = vehicleID,
                ServiceName = serviceName,
                DateOfService = dateOfService,
                WorkDone = workDone,
                Mileage = mileage,
                ServiceCost = serviceCost,
                
            };

            //add new service, save changes and return newly added service
            db.Services.Add(s);
            db.SaveChanges();
            return s;
        }//AddService
        public Service GetServiceById(int id)
        {
            return db.Services.FirstOrDefault(s => s.Id == id);
        }//GetServiceById
        public bool DeleteService(int id)
        {
            var s = GetServiceById(id);
            if ( s == null)
            {
                return false;
            }
            db.Services.Remove(s);
            db.SaveChanges();
            return true;
        }//DeleteService

        // Return all services with Related vehicles
        public IList<Service> GetAllServices()
        {
            // return services with associated vehicles
            return db.Services
                    .Include(s => s.Vehicle)
                    .ToList();
        }

    }
}