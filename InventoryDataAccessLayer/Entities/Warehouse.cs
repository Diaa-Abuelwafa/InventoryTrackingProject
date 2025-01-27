using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataAccessLayer.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Not Use Just Relationship With Product Entity
        public List<Product> Products { get; set; }
    }
}
