using DAL.Interface;
using DAL.Memory;
using DAL.SQLcontext;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ItemLogic
    {
        private readonly iItem _context;

        public ItemLogic()
        {
            _context = new ItemContext();
        }
        public bool AddItem(Item item)
        {
            return _context.AddItem(item.ConvertToDTO(item));
        }

        public bool RemoveItem(string id)
        {
            return _context.RemoveItem(id);
        }

        public bool EditItem(Item item)
        {
            return _context.EditItem(item.ConvertToDTO(item));
        }

        public List<Item> GetItem()
        {
            var collectedItems = _context.GetItem().ConvertAll(x => new Item { ItemID = x.ItemID, Price = Math.Round(x.Price, 2), ProductName = x.ProductName, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT });
            return collectedItems.OrderByDescending(x => x.InStock).ThenBy(x => x.ProductName).ToList();
        }

        public Item GetItemByID(string id)
        {
            return new Item(_context.GetItemByID(id));
        }

        public List<Item> GetPriceOfList(List<Item> ListOfItems)
        {
            foreach (var item in ListOfItems)
            {
                item.Price = Math.Round(_context.GetItemByID(item.ItemID).Price, 2);
            }
            return ListOfItems;
        }
    }
}
