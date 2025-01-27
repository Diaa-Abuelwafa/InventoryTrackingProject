using InventoryDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccessLayer.Interfaces
{
    public interface IWarehouseService
    {
        public List<Warehouse> GetAll();
        public int Add(string WarehouseName);
        public int Edit(string OldWarehouseName, string NewWarehouseName);
        public int Delete(string WarehouseName);
    }
}
