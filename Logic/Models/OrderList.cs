using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class OrderList
    {
        public string OrderID { get; set; }
        public List<Item> OrderItem { get; set; }
        public int Amount { get; set; }

        public OrderList()
        { }

        public OrderList(OrderlistDTO order)
        {
            OrderID = order.OrderID;
            OrderItem = order.OrderItem.ConvertAll(x => new Item { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT });
            Amount = order.Amount;
        }

        public OrderlistDTO ConvertToDTO(OrderList order)
        {
            var returnedOrder = new OrderlistDTO()
            {
                OrderID = order.OrderID,
                OrderItem = order.OrderItem.ConvertAll(x => new ItemDTO { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT }),
                Amount = order.Amount
            };
            return returnedOrder;
        }

        public bool AddItem(string id)
        {
            OrderItem.Add(new Item() { ItemID = id } );
            return true;
        }

        public bool AddListOfItems(List<Item> items)
        {
            OrderItem.AddRange(items);
            return true;
        }
    }
}
