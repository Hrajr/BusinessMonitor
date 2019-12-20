using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public class OrderlistContext : iOrderlist
    {
        public OrderlistDTO GetOrderByID(string iD)
        {
            throw new NotImplementedException();
        }
    }
}
