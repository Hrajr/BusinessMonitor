using DAL.Interface;
using DAL.Interface.DTO;
using DAL.SQLcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Models
{
    public class OrderList
    {
        private readonly iOrderlist _context;
        private readonly ItemLogic _itemLogic = new ItemLogic();
        public string OrderID { get; set; }
        public List<Item> OrderItem { get; set; }

        public OrderList()
        {
            _context = new OrderlistContext();
        }

        public OrderList(List<Item> list)
        {
            OrderItem = list;
        }

        public OrderList(OrderlistDTO order)
        {
            _context = new OrderlistContext();
            OrderID = order.OrderID;
            OrderItem = order.OrderItem.ConvertAll(x => new Item { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT });
        }

        public OrderlistDTO ConvertToDTO(OrderList order)
        {
            var returnedOrder = new OrderlistDTO()
            {
                OrderID = order.OrderID,
                OrderItem = order.OrderItem.ConvertAll(x => new ItemDTO { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT })
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

        public OrderList GetOrderByID(string ID)
        {
            var correspondingOrderlist = new OrderList(_context.GetOrderByID(ID));
            for (int i = 0; i < correspondingOrderlist.OrderItem.Count; i++)
            {
                var correspondingItem = _itemLogic.GetItemByID(correspondingOrderlist.OrderItem[i].ItemID);
                var currentItem = correspondingOrderlist.OrderItem.FirstOrDefault(x => x.ItemID == correspondingOrderlist.OrderItem[i].ItemID);
                if (currentItem != null)
                {
                    currentItem.ProductName = correspondingItem.ProductName;
                    currentItem.Description = correspondingItem.Description;
                    currentItem.InStock = correspondingItem.InStock;
                }
            }
            return correspondingOrderlist;
        }

        public bool AddOrderlist(string ID, OrderList items)
        {
            try
            {
                for (int i = 0; i < items.OrderItem.Count; i++)
                {
                    items.OrderItem[i].Price = _itemLogic.GetItemByID(items.OrderItem[i].ItemID).Price;
                    _context.AddOrderlist(ID, items.OrderItem[i].ItemID, items.OrderItem[i].Amount, items.OrderItem[i].Price);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOrderlist(string oldID, string newID, OrderList items)
        {
            if (AddOrderlist(newID, items) && DeleteOrder(oldID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItemFromOrder(string ID, string ItemID)
        {
            return _context.RemoveItemFromOrder(ID, ItemID);
        }

        public bool DeleteOrder(string ID)
        {
            return _context.RemoveOrder(ID);
        }

        public decimal GetTotalPrice(OrderList items)
        {
            var totalPrice = new decimal();
            foreach (var item in items.OrderItem)
            {
                totalPrice = totalPrice + (item.Price * item.Amount);
            }
            return totalPrice;
        }
    }
}
