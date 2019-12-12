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
            model.ListOfItems = _itemLogic.GetItem();
            //model.ListOfItems.AddRange(allItems);
            return View(model);
        }

        [HttpGet]
        [Route("AddItem")]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitItem(string Name, string Desc, string Price, string VAT, string Amount, bool Available)
        {
            var newItem = new Item
            {
                ProductName = Name,
                Description = Desc,
                VAT = Convert.ToInt16(VAT),
                Price = Convert.ToDouble(Price),
                Amount = Convert.ToInt16(Amount),
                InStock = Available
            };
            if (_itemLogic.AddItem(newItem))
            { return View("AddItem"); }
            return View("Item");
        }

        [HttpPost]
        public IActionResult SaveItem(string ID, string Name, string Desc, string Price, string VAT, string Amount, bool Available)
        {
            var newItem = new Item
            {
                ItemID = ID,
                ProductName = Name,
                Description = Desc,
                VAT = Convert.ToInt16(VAT),
                Price = Convert.ToDouble(Price),
                Amount = Convert.ToInt16(Amount),
                InStock = Available
            };
            if (_itemLogic.EditItem(newItem))
            { return View("EditItem"); }
            return View("Item");
        }

        [HttpPost]
        public IActionResult RemoveItem(string id)
        {
            _itemLogic.RemoveItem(id);
            return View("Item");
        }

        [HttpGet]
        [Route("EditItem")]
        public IActionResult EditItem(string id)
        {
            var item = new ItemViewModel()
            {
                ItemID = "Test",
                ProductName = "Name",
                Description = "Desc",
                Price = 2,
                VAT = 202,
                Amount = 50,
                InStock = false
            };
            return View("EditItem", item);
        }
    }
}