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
        public List<Invoice> ListOfInvoices = new List<Invoice>();
        public List<Reference> ListOfReferences = new List<Reference>();
        public List<Item> ListOfItems = new List<Item>();

        public enum InvoiceType
        {
            Purchase, Sale, CreditNote
        }
    }
}
