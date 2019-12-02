using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessMonitor.Models
{
    public class ItemViewModel
    {
        public class ViewItem
        {
            public string ItemID { get; set; }
            public string Description { get; set; }
            public int VAT { get; set; }
            public double Price { get; set; }
            public int Amount { get; set; }
            public bool InStock { get; set; }

            public ViewItem(Item item)
            {
                ItemID = item.ItemID;
                Description = item.Description;
                VAT = item.VAT;
                Price = item.Price;
                Amount = item.Amount;
                InStock = item.InStock;
            }
        }
        public List<Item> ListOfItems;
        public List<ViewItem> ListOfItem;
    }
}
