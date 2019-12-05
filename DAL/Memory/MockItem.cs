using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Memory
{
    public class MockItem
    {
        public List<ItemDTO> ItemsMock = new List<ItemDTO>()
        {
            new ItemDTO{ItemID = "TestItemID1", VAT = 21, Price = 15.80, InStock = true,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID2", VAT = 9, Price = 88.70, InStock = true,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID3", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID4", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID5", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID6", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID7", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID8", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID9", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID10", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID11", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"},
            new ItemDTO{ItemID = "TestItemID12", VAT = 0, Price = 31.60, InStock = false,
            Description = "This is a mockItem description for testing purpose"}
        };
    }
}
