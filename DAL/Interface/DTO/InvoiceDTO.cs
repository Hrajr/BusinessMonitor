using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface.DTO
{
    public class InvoiceDTO
    {
        public string InvoiceNumber { get; set; }
        public Invoicetype TypeOfInvoice { get; set; }
        public ReferenceDTO InvoiceReference { get; set; }
        public OrderlistDTO InvoiceOrder { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public UserDTO InvoiceUser { get; set; }
        public bool PaymentStatus { get; set; } = false;
    }
}
