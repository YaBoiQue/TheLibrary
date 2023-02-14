using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Data.SeedData
{
    public static class SeedDatabase
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {

            using ApplicationDbContext context = new(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            /*
            // Look for any Users.
            // NOTE:  Not robust enough yet.
            if (!context.Users.Any())
            {
                SeedUsers(context);
                context.SaveChanges();
            }
            */

            // Look for any VehicleTypes.
            // NOTE:  Not robust enough yet.
            if (!await context.VehicleType.AnyAsync())
            {
                await SeedVehicleTypes(context);
                _ = await context.SaveChangesAsync();
            }
        }

        private static async Task SeedVehicleTypes(ApplicationDbContext context)
        {
            string fileName = @"Data/SeedData/VehicleTypes.json";
            string jsonlist = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<VehicleTypeList>(jsonlist);

            if (data != null)
            {
                foreach (string item in data.VehicleTypes)
                {
                    VehicleType vehicleType = new VehicleType(item);
                    context.VehicleType.AddRange(vehicleType);
                    _ = await context.SaveChangesAsync();
                }
            }
        }

        private class VehicleTypeList
        {
            public VehicleTypeList(VehicleTypeList vehicleTypeList)
            {
                VehicleTypes = vehicleTypeList.VehicleTypes;
            }

            public string[] VehicleTypes { get; set; }
        }
    }
}

