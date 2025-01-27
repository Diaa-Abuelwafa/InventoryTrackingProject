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
    public class ProductService : IProductService
    {
        private readonly AppDbContext Context;

        public ProductService(AppDbContext Context)
        {
            this.Context = Context;
        }
        public int Add(Product Item)
        {
            Context.Products.Add(Item);

            return Context.SaveChanges();
        }

        public int Delete(int ProductId)
        {
            var Item = Context.Products.FirstOrDefault(x => x.Id == ProductId);

            if(Item is null)
            {
                return 0;
            }

            Context.Products.Remove(Item);

            return Context.SaveChanges();
        }

        public int Edit(int ProductId, Product Item)
        {
            var ItemFromDb = Context.Products.Include(x => x.Warehouse).FirstOrDefault(x => x.Id == ProductId);

            if (ItemFromDb is null)
            {
                return 0;
            }

            ItemFromDb.SKU = Item.SKU;
            ItemFromDb.Name = Item.Name;
            ItemFromDb.Description = Item.Description;
            ItemFromDb.WarehouseId = Item.WarehouseId;

            return Context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return Context.Products.Include(x => x.Warehouse).ToList();
        }

        public Product GetById(int ProductId)
        {
            var Item = Context.Products.Include(x => x.Warehouse).FirstOrDefault(x => x.Id == ProductId);

            if(Item is not null)
            {
                return Item;
            }

            return null;
        }
    }
}
