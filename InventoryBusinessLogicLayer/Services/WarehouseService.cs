using InventoryBusinessLogicLayer.Contexts;
using InventoryDataAccessLayer.Entities;
using InventoryDataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBusinessLogicLayer.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly AppDbContext Context;

        public WarehouseService(AppDbContext Context)
        {
            this.Context = Context;
        }
        public int Add(string WarehouseName)
        {
            // To Ensure Unique

            Warehouse Item = Context.Warehouses.FirstOrDefault(x => x.Name == WarehouseName);

            if(Item is not null)
            {
                return 0;
            }

            Warehouse NewItem = new Warehouse()
            {
                Name = WarehouseName
            };

            Context.Warehouses.Add(NewItem);

            return Context.SaveChanges();
        }

        public int Delete(string WarehouseName)
        {
            Warehouse Item = Context.Warehouses.FirstOrDefault(x => x.Name == WarehouseName);

            if(Item is null)
            {
                return 0;
            }

            Context.Warehouses.Remove(Item);

            return Context.SaveChanges();
        }

        public int Edit(string OldWarehouseName, string NewWarehouseName)
        {
            Warehouse Item = Context.Warehouses.FirstOrDefault(x => x.Name == OldWarehouseName);

            if(Item is null)
            {
                return 0;
            }

            Item.Name = NewWarehouseName;

            return Context.SaveChanges();
        }

        public List<Warehouse> GetAll()
        {
            return Context.Warehouses.Include(x => x.Products).ToList();
        }
    }
}
