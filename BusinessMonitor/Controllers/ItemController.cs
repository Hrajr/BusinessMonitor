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
                Price = Convert.ToDecimal(Price),
                Amount = Convert.ToInt16(Amount),
                InStock = Available
            };
            if(_itemLogic.AddItem(newItem))
            { return RedirectToAction("Item"); }
            return View("AddItem");
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
                Price = Convert.ToDecimal(Price),
                Amount = Convert.ToInt16(Amount),
                InStock = Available
            };
            if (_itemLogic.EditItem(newItem))
            { return RedirectToAction("Item"); }
            return View("EditItem");
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
            var item = new ItemViewModel(_itemLogic.GetItemByID(id));
            return View("EditItem", item);
        }
    }
}