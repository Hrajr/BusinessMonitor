using DAL.Interface;
using DAL.SQLcontext;
using Logic.Models;
using System;
using System.Collections.Generic;
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

        public List<Item> GetItem()
        {
            return _context.GetItem().ConvertAll(x => new Item { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT });
        }

        public Item GetItemByID(string id)
        {
            return new Item(_context.GetItemByID(id));
        }
    }
}
