using InventoryDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccessLayer.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product GetById(int ProductId);
        public int Add(Product Item);
        public int Edit(int ProductId, Product Item);
        public int Delete(int ProductId);
    }
}
