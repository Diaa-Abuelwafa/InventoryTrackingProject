using InventoryDataAccessLayer.Entities;
using InventoryDataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPresentationLayer.Controllers
{
    public class StockController : Controller
    {
        private readonly IProductService ProductService;

        public StockController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }
        public IActionResult Index()
        {
            var Products = ProductService.GetAll(null);

            return View("Index", Products);
        }

        public IActionResult MakeStock(int id)
        {
            var Product = ProductService.GetById(id);

            return View("MakeStock", Product);
        }

        public IActionResult SaveStock(int id, int NewValueForQuantity)
        {
            var Product = ProductService.GetById(id);

            ProductService.EditQuantity(id, NewValueForQuantity);

            return RedirectToAction("Index");
        }
    }
}
