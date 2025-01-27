using InventoryDataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPresentationLayer.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService WarehouseService;

        public WarehouseController(IWarehouseService WarehouseService)
        {
            this.WarehouseService = WarehouseService;
        }
        public IActionResult Index()
        {
            var Data = WarehouseService.GetAll();

            return View(Data);
        }

        public IActionResult Edit(string WarehouseName)
        {
            return View("Edit", WarehouseName);
        }

        public IActionResult EditName(string NewWarehouseName, string OldWarehouseName)
        {

            WarehouseService.Edit(OldWarehouseName, NewWarehouseName);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string WarehouseName)
        {
            return View("Delete", WarehouseName);
        }

        public IActionResult DeleteName(string WarehouseName)
        {
            // For Ensure

            WarehouseService.Delete(WarehouseName);

            return RedirectToAction("Index");
        }

        public IActionResult Add(string newWarehouseName)
        {
            var Result = WarehouseService.Add(newWarehouseName);

            return RedirectToAction("Index");
        }
    }
}
