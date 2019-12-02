using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessMonitor.Models
{
    public class InvoiceViewModel
    {
        public class User
        {
            public string ID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Address { get; set; }
            public string Zipcode { get; set; }
            public string Place { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }

        public class Reference
        {
            public string ID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string Address { get; set; }
            public string Zipcode { get; set; }
            public string Place { get; set; }
            public string Country { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Bank { get; set; }
            public string BIC { get; set; }
            public string IBAN { get; set; }
            public string KvK { get; set; }
            public string VAT { get; set; }
            public bool Doubtfull { get; set; }
            public DateTime Date { get; set; }
            public string Note { get; set; }
        }

        public class Orderlist
        {
            public int OrderID { get; set; }
            public List<Item> OrderItem { get; set; }
            public int Amount { get; set; }
        }

        public class Item
        {
            public string ItemID { get; set; }
            public string Description { get; set; }
            public int VAT { get; set; }
            public double Price { get; set; }
            public int Amount { get; set; }
            public bool InStock { get; set; }
        }
    }
}
