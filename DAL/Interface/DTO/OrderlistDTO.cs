using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface.DTO
{
    public class OrderlistDTO
    {
        public string OrderID { get; set; }
        public List<ItemDTO> OrderItem { get; set; }
    }
}
