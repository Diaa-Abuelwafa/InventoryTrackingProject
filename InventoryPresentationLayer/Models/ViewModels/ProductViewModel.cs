using InventoryDataAccessLayer.Entities;

namespace InventoryPresentationLayer.Models.ViewModels
{
    public class ProductViewModel
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WarehouseId { get; set; }
    }
}
