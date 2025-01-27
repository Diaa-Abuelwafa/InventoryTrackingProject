using InventoryDataAccessLayer.Entities;
using InventoryDataAccessLayer.Interfaces;
using InventoryPresentationLayer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        private readonly IWarehouseService WarehouseService;

        public ProductController(IProductService ProductService, IWarehouseService WarehouseService)
        {
            this.ProductService = ProductService;
            this.WarehouseService = WarehouseService;
        }
        public IActionResult Index(int? indx = null)
        {
            var Data = ProductService.GetAll(indx);

            ViewBag.Warehouses = WarehouseService.GetAll();
            ViewBag.Products = ProductService.GetAll(indx);

            return View("Index");
        }

        public IActionResult Add(ProductViewModel Item)
        {
            if(ModelState.IsValid)
            {
                Product NewItem = new Product()
                {
                    Name = Item.Name,
                    SKU = Item.SKU,
                    Description = Item.Description,
                    WarehouseId = Item.WarehouseId
                };

                ProductService.Add(NewItem);

                return RedirectToAction("Index");
            }

            return View("Index", Item);
        }

        public IActionResult Edit(int id)
        {
            var Item = ProductService.GetById(id);

            ViewBag.Warehouses = WarehouseService.GetAll();

            return View("Edit", Item);
        }

        public IActionResult EditProduct(int ProductId, ProductViewModel Item)
        {
            if(ModelState.IsValid)
            {
                Product ItemToStore = new Product()
                {
                    Name = Item.Name,
                    SKU = Item.SKU,
                    Description = Item.Description,
                    WarehouseId = Item.WarehouseId
                };

                ProductService.Edit(ProductId, ItemToStore);

                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        public IActionResult Delete(int id)
        {
            var Item = ProductService.GetById(id);

            return View("Delete", Item);
        }

        public IActionResult DeleteProduct(int ProductId)
        {
            if(ModelState.IsValid)
            {
                ProductService.Delete(ProductId);

                return RedirectToAction("Index");
            }

            return View("Delete");
        }
    }
}
