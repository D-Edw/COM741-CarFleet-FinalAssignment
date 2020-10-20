using System;
using Xunit;

// importing dependencies from the Data Project
using VMS.Data.Models;
using VMS.Data.Services;

namespace VMS.Test
{
    public class TestVehicleService
    {
       // define a set of appropriate tests to test the vehicle service class
       private readonly IVehicleService svc;

       public TestVehicleService ()
       {
           //general arrangement
           svc = new VehicleDbService();

           //ensure database is empty before each test
           svc.Initialise();
       }

       [Fact]
       public void GetAllVehicles_WhenNone_ShouldReturn0()
       {
           //act
           var vehicles = svc.GetAllVehicles();
           var count = vehicles.Count;

           //assert
           Assert.Equal(0, count);
       }//GetAllVehicles_WhenNone_ShouldReturn0

       [Fact]
       public void AddVehicle_WhenNone_ShouldSetAllProperties()
       {
           //act
           var v = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");

           //assert - that vehicle is not null
           Assert.NotNull(v);

           //now assert that the vehicle properties were set properly
           Assert.Equal(v.Id, v.Id);
           Assert.Equal("Ford", v.Make);
           Assert.Equal("Focus", v.Model);
           Assert.Equal("SVZ 9999", v.Reg);
           Assert.Equal("Green", v.Colour);
           Assert.Equal(new DateTime(2007,12,01), v.DateOfReg);
           Assert.Equal("Manual", v.Transmission);
           Assert.Equal(200, v.CO2Rating);
           Assert.Equal("Petrol", v.Fuel);
           Assert.Equal("Hatchback", v.BodyType);
           Assert.Equal(5, v.NoOfDoors);
       }//AddVehicle_WhenNone_ShouldSetAllProperties

       [Fact]
       public void GetAllVehicles_With2Added_ShouldReturn2()
       {
           //arrange
           var v1 = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");
           var v2 = svc.AddVehicle("Volkswagen", "Golf", "SVZ 9998", "Red", new DateTime(2008,12,01), "Manual", 205, "Diesel", "Hatchback", 3,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");

           //act
           var vehicles = svc.GetAllVehicles();
           var count = vehicles.Count;

           //assert
           Assert.Equal(2, count);

       }//GetAllVehicles_With2Added_ShouldReturn2

       [Fact]
       public void GetVehiclesById_WhenNone_ShouldReturnNull()
       {
           //act
           var vehicle = svc.GetVehicleById(1); // non-existent vehicle

           //assert
           Assert.Null(vehicle);
       }//GetVehiclesById_WhenNone_ShouldReturnNull

       [Fact]
       public void GetVehicleById_WhenAdded_ShouldReturnVehicle()
       {
           //act
           var v = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");

           var nv = svc.GetVehicleById(v.Id);

           //assert
           Assert.NotNull(nv);
           Assert.Equal(v.Id, nv.Id);
       }//GetVehicleById_WhenAdded_ShouldReturnVehicle

       [Fact]
       public void DeleteVehicle_ThatExists_ShouldReturnTrue()
       {
           //act
           var v = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");
           var deleted = svc.DeleteVehicle(v.Id);

           //assert
           Assert.True(deleted);
       }//DeleteVehicle_ThatExists_ShouldReturnTrue

       [Fact]
       public void DeleteVehicle_ThatDoesntExist_ShouldNotWork()
       {
           //act
           var deleted = svc.DeleteVehicle(0);

           //assert
           Assert.False(deleted);
       }//DeleteVehicle_ThatDoesntExist_ShouldNotWork

       [Fact]
       public void UpdateVehicle_WhenAdded_ShouldReturnUpdatedVehicle()
       {
           //act
           var v = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");

           var update = svc.UpdateVehicle(v.Id, v);

           update.Make = "Fiat";
           update.Model = "Punto";
           update.Reg = "SVZ 0000";
           update.Colour = "Red";
           update.DateOfReg = new DateTime(2000,11,1);
           update.Transmission = "Automatic";
           update.CO2Rating = 100;
           update.Fuel = "Diesel";
           update.BodyType = "Saloon";
           update.NoOfDoors = 3;

           //assert
           Assert.Equal(v.Id, update.Id);
           Assert.Equal("Fiat", update.Make);
           Assert.Equal("Punto", update.Model);
           Assert.Equal("SVZ 0000", update.Reg);
           Assert.Equal("Red", update.Colour);
           Assert.Equal(new DateTime(2000,11,1), update.DateOfReg);
           Assert.Equal("Automatic", update.Transmission);
           Assert.Equal(100, update.CO2Rating);
           Assert.Equal("Diesel", update.Fuel);
           Assert.Equal("Saloon", update.BodyType);
           Assert.Equal(3, update.NoOfDoors);
       
       }//UpdateVehicle_WhenAdded_ShouldReturnUpdatedVehicle

       
       [Fact]
       public void AddService_WhenNone_ShouldReturnAllProperties()
       {
          // arrange
          var v = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");

          //act
          var s = svc.AddService(1, "John", new DateTime(2020,1,20), "Brakes", 120000, 100);

          //assert - that service is not null
          Assert.NotNull(s);

          // now assert that the properties were set properly
          Assert.Equal(s.Id, s.Id);
          Assert.Equal("John", s.ServiceName);
          Assert.Equal(new DateTime(2020,1,20), s.DateOfService);
          Assert.Equal("Brakes", s.WorkDone);
          Assert.Equal(120000, s.Mileage);
          Assert.Equal(100, s.ServiceCost);
          Assert.Equal(1, v.Id);

       }//AddService_WhenNone_ShouldReturnAllProperties

       [Fact]
       public void GetServiceByID_WhenNone_ShouldReturnNull()
       {
           //act
           var service = svc.GetServiceById(1); // non-existent service

           //assert
           Assert.Null(service);
       }//GetServiceByID_WhenNone_ShouldReturnNull

       [Fact]
       public void GetServiceByID_WhenAdded_ShouldReturnService()
       {
          // arange
          var v = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");

          //act
          var s = svc.AddService(1, "John", new DateTime(2020,1,20), "Brakes", 120000, 100);

          var ns = svc.GetServiceById(s.Id);

          //assert
          Assert.NotNull(ns);
          Assert.Equal(s.Id, ns.Id);
       }//GetServiceByID_WhenAdded_ShouldReturnService

       [Fact]
       public void DeleteService_ThatExists_ShouldReturnTrue()
       {
          // arange
          var v = svc.AddVehicle("Ford", "Focus", "SVZ 9999", "Green", new DateTime(2007,12,01), "Manual", 200, "Petrol", "Hatchback", 5,"https://lh3.googleusercontent.com/proxy/zTidBBaHuGDZDoVq8EEqeG9liCDdLW9mC69SIRoFclIutxSZCYRutEMGl0PyB7olOR0ZWjrLtOk2QaSHqCUxKv0EqEqT52Q6bux-iJkBE0gYhjY8c46TotG1zmjfchFc6qVUy2o3Cui4Ds0Gwlo");

          //act
          var s = svc.AddService(1, "John", new DateTime(2020,1,20), "Brakes", 120000, 100);
          var deleted = svc.DeleteService(s.Id);

          //assert
          Assert.True(deleted);
       }//DeleteService_ThatExists_ShouldReturnTrue

       [Fact]
       public void DeleteService_ThatDoesntExist_ShouldNotWork()
       {
           // act
           var deleted = svc.DeleteService(0);

           //assert
           Assert.False(deleted);
       }//DeleteService_ThatDoesntExist_ShouldNotWork



      


       
 
    }
}