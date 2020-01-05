using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface iOrderlist
    {
        OrderlistDTO GetOrderByID(string ID);
        bool AddOrderlist(string ID, string ItemID, int Amount, decimal Price);
        bool RemoveOrder(string ID);
        bool RemoveItemFromOrder(string ID, string ItemID);
    }
}
