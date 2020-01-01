using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Memory
{
    public class MockOrderlist
    {
        public static MockItem Testing = new MockItem();
        public OrderlistDTO OrderListMock = new OrderlistDTO
        {
            OrderID = "1",
            OrderItem = Testing.ItemsMock
        };
    }
}
