using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccessLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
