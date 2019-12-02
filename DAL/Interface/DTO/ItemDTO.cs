using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface.DTO
{
    public class ItemDTO
    {
        public string ItemID { get; set; }
        public string Description { get; set; }
        public int VAT { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool InStock { get; set; }

        public ItemDTO()
        { }

        public ItemDTO(string itemID, string description, int vat, double price, int amount, bool instock)
        {
            ItemID = itemID;
            Description = description;
            VAT = vat;
            Price = price;
            Amount = amount;
            InStock = instock;
        }
    }
}
