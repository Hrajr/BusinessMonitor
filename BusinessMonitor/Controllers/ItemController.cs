using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessMonitor.Models;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessMonitor.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemLogic _itemLogic;
        private ItemViewModel model = new ItemViewModel();
        public ItemController()
        {
            _itemLogic = new ItemLogic();
        }

        [HttpGet]
        [Route("Item")]
        public IActionResult Item()
        {
            var allItems = _itemLogic.GetItem();
            model.ListOfItems.AddRange(allItems);
            return View(model);
        }

        [HttpPost]
        [Route("AddItem")]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        [Route("SubmitItem")]
        public IActionResult SubmitItem(IFormCollection formCollection)
        {
            if (!ModelState.IsValid)
            { return View("AddItem"); }
            var newItem = new Item
            {
                Description = formCollection["Description"],
                VAT = Convert.ToInt16(formCollection["VAT"]),
                Price = Convert.ToDouble(formCollection["Price"]),
                Amount = Convert.ToInt16(formCollection["Amount"])
            };
            if (_itemLogic.AddItem(newItem))
            { return View("AddItem"); }
            return View("Item");
        }

        [HttpPost]
        public IActionResult RemoveItem(string id)
        {
            _itemLogic.RemoveItem(id);
            return RedirectToAction("Item");
        }

        [HttpPost]
        [Route("OpenItem")]
        public IActionResult OpenItem(string id)
        {
            var openItem = new ItemViewModel.ViewItem(_itemLogic.GetItemByID(id));
            return View("OpenItem", openItem);
        }
    }
}