﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface.DTO
{
    public class OrderlistDTO
    {
        public int OrderID { get; set; }
        public List<ItemDTO> OrderItem { get; set; }
        public int Amount { get; set; }
    }
}
