﻿using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface iOrderlist
    {
        OrderlistDTO GetOrderByID(string iD);
    }
}
