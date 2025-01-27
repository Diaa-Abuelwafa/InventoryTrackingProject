using InventoryBusinessLogicLayer.Contexts;
using InventoryDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryBusinessLogicLayer.SeedData
{
    public static class SeedHelper
    {
        public static void Seed(AppDbContext Context)
        {
            if(Context.Warehouses.Count() == 0)
            {
                var JsonData = File.ReadAllText("../InventoryBusinessLogicLayer/SeedData/Warehouses.json");

                if(JsonData is not null)
                {
                    var Data = JsonSerializer.Deserialize<List<Warehouse>>(JsonData);

                    if(Data is not null)
                    {
                        Context.Warehouses.AddRange(Data);
                        Context.SaveChanges();
                    }
                }
            }

            if (Context.Products.Count() == 0)
            {
                var JsonData = File.ReadAllText("../InventoryBusinessLogicLayer/SeedData/Products.json");

                if (JsonData is not null)
                {
                    var Data = JsonSerializer.Deserialize<List<Product>>(JsonData);

                    if (Data is not null)
                    {
                        Context.Products.AddRange(Data);
                        Context.SaveChanges();
                    }
                }
            }
        }
    }
}
