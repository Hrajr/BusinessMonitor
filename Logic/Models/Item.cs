using DAL.Interface;
using DAL.Interface.DTO;
using DAL.SQLcontext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Item
    {
        public string ItemID { get; set; }
        public string Description { get; set; }
        public int VAT { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool InStock { get; set; }

        public Item()
        { }

        public Item(string id, string description, int vat, double price, int amount, bool instock)
        {
            ItemID = id;
            Description = description;
            VAT = vat;
            Price = price;
            Amount = amount;
            InStock = instock;
        }

        public Item(ItemDTO item)
        {
            ItemID = item.ItemID;
            Description = item.Description;
            VAT = item.VAT;
            Amount = item.Amount;
            InStock = item.InStock;
        }

        public ItemDTO ConvertToDTO(Item item)
        {
            var convertedItem = new ItemDTO()
            {
                ItemID = item.ItemID,
                Description = item.Description,
                VAT = item.VAT,
                Price = item.Price,
                Amount = item.Amount,
                InStock = item.InStock
            };
            return convertedItem;
        }
    }
}
