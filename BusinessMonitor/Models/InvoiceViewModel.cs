using DAL.Interface.DTO;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessMonitor.Models
{
    public class InvoiceViewModel
    {
        public string InvoiceNumber { get; set; }
        public Reference InvoiceReference { get; set; }
        public OrderList InvoiceOrder { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PayementDate { get; set; }
        public User InvoiceUser { get; set; }

        public Invoice SingleInvoice = new Invoice();
        //public List<Item> items = new List<Item>() {
        //new Item{ItemID = "TestItemID1", ProductName="TestName1", VAT = 21, Price = 15.80, InStock = true,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID2", ProductName="TestName2", VAT = 9, Price = 88.70, InStock = true,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID3", ProductName="TestName3",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID4", ProductName="TestName4",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID5", ProductName="TestName5",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID6", ProductName="TestName6",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID7", ProductName="TestName7",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID8", ProductName="TestName8",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID9", ProductName="TestName9",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID10", ProductName="TestName10",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID11", ProductName="TestName11",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"},
        //    new Item{ItemID = "TestItemID12", ProductName="TestName12",VAT = 0, Price = 31.60, InStock = false,
        //    Description = "This is a mockItem description for testing purpose"}
        //};
        public List<Invoice> ListOfInvoices = new List<Invoice>();
        public List<Reference> ListOfReferences = new List<Reference>();
        public List<Item> ListOfItems = new List<Item>();

        public enum InvoiceType
        {
            Purchase, Sale, CreditNote
        }
    }
}
