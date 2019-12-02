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

        public Invoice SingleInvoice;
        public List<Invoice> ListOfInvoices;
    }
}
