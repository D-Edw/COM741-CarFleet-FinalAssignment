using System;
using System.Collections.Generic;
using VMS.Data.Models;
using VMS.Data.Repositories;
using VMS.Data.Services;


namespace VMS.Data.Seeders
{
    public static class ServiceDataSeeder
    {
   
        public static void Seed(IVehicleService svc)
        {    
            // use the service to seed the database with sample data 
            // when running the web project

            svc.Initialise();

            //create some vehicles
            var v1 = svc.AddVehicle("Ford", "Focus", "GUI 1234", "Red", new DateTime (2018,01,01), "Manual", 200, "Petrol", "Hatchback", 5, "https://www.cstatic-images.com/car-pictures/xl/usc80foc351a021001.png");
            var v2 = svc.AddVehicle("Flintstone", "Bedrock", "Yaba-Daba D00", "Stoneage White", new DateTime (1960,09,30), "Flintstones", 1, "Water", "Coupe", 1,"https://i.dailymail.co.uk/i/pix/scaled/2011/07/22/article-2017721-0D1DEF0400000578-763_308x185.jpg");
            var v3 = svc.AddVehicle("Fiat", "Punto", "HUI 9999", "Green", new DateTime (1999,6,11), "Manual", 250, "Petrol", "Hatchback", 3, "https://s1.cdn.autoevolution.com/images/gallery/FIATPunto5Door-2411_1.jpg");
            var v4 = svc.AddVehicle("Vauxhall", "Blob Mobile", "P998 HUX", "Pink/Yellow Polka Dots", new DateTime (1992,11,23), "Manual", 150, "Petrol", "Hatchback", 5,"https://s0.geograph.org.uk/geophotos/03/07/51/3075175_15fa2751.jpg");
            var v5 = svc.AddVehicle("Volkswagen", "Golf", "GNZ 5678", "Black", new DateTime (2008,10,30), "Manual", 150, "Diesel", "Hatchback", 3, "https://lh3.googleusercontent.com/proxy/skUAwaTjATs4Tn0zymKEir1fZPqBCJfFzXIJXr_UdsJpj7ZrNlWbtTpdf_Tsowfh2WH1FOcSBPkThVuWz3lyfyvoz45-DK9l9QFHVOe6YmzQxW-EThQGvzH6irDUahSxQQWHH8BoebSTzQImcxkMIOpDoh4DP0ZXunW9mbr0uL3kYWpnB9PoIPYEeg");
            var v6 = svc.AddVehicle("Genepax", "H2O Power", "H20", "Ocean Blue", new DateTime (2013,01,31), "Automatic", 1, "Water", "Coupe", 2,"https://www.greenoptimistic.com/wp-content/uploads/2008/06/genepax-water-powered-car1.jpg");
            var v7 = svc.AddVehicle("Bozo", "Clown Car", "C10 WN", "Multicolour", new DateTime (1950,06,10), "Manual", 300, "Coal", "Coupe", 2,"https://i.imgflip.com/3f5cjo.jpg");
            var v8 = svc.AddVehicle("Wayne", "Batmobile", "DC 2000", "Bat Black", new DateTime (1939,05,01), "Manual", 300, "Petrol", "Saloon", 2,"https://thumbor.forbes.com/thumbor/960x0/https%3A%2F%2Fblogs-images.forbes.com%2Fdavidhochman%2Ffiles%2F2018%2F03%2F60812872-770-0%402X-1200x800.jpg");
            var v9 = svc.AddVehicle("Arkansas", "Chuggabug", "W-R4C35", "Wooden Brown", new DateTime (1968,09,14), "Manual", 300, "Coal", "Saloon", 2,"https://live.staticflickr.com/2889/9307329490_1d286d5602_b.jpg");
            var v10 = svc.AddVehicle("Peugeot", "307", "TVZ 6666", "White", new DateTime (2007,02,14), "Manual", 100, "Diesel", "Hatchback", 5,"https://upload.wikimedia.org/wikipedia/commons/8/80/2001-2005_Peugeot_307_%28T5%29_5-door_hatchback_02.jpg");
            var v11 = svc.AddVehicle("Reliant", "Regal", "BWC 94F", "Yellow", new DateTime (1981,09,08), "Manual", 200, "Petrol", "Hatchback", 3,"https://cdn.images.express.co.uk/img/dynamic/24/750x445/879050.jpg");

            //create some services
            var s1 = svc.AddService(1, "Roger", new DateTime (2020,01,23),"MOT service", 70000, 130.00);
            var s2 = svc.AddService(2, "John", new DateTime (2019,06,25),"MOT service", 200000, 130.00);
            var s3 = svc.AddService(3, "Roger", new DateTime (2019,10,13),"MOT service", 300000, 130.00);
            var s4 = svc.AddService(4, "John", new DateTime (2019,07,03),"MOT service", 245000, 130.00);






        }
    }
}
   