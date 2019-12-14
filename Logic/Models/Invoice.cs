using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public Invoicetype TypeOfInvoice { get; set; }
        public Reference InvoiceReference { get; set; }
        public OrderList InvoiceOrder { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PayementDate { get; set; }
        public User InvoiceUser { get; set; }
        public bool PaymentStatus { get; set; } = false;

        public Invoice()
        { }

        public Invoice(string newIN, string referenceID, string itype, string userID, DateTime id, DateTime pd, bool newstatus)
        {
            InvoiceNumber = newIN;
            TypeOfInvoice = (Invoicetype)System.Enum.Parse(typeof(Invoicetype), itype);
            InvoiceReference = new Reference() { ID = referenceID };
            InvoiceUser = new User() { ID = userID };
            InvoiceDate = id;
            PayementDate = pd;
            PaymentStatus = newstatus;
        }

        public Invoice(InvoiceDTO invoice)
        {
            InvoiceNumber = invoice.InvoiceNumber;
            TypeOfInvoice = invoice.TypeOfInvoice;
            InvoiceReference = new Reference(invoice.InvoiceReference);
            InvoiceOrder = new OrderList(invoice.InvoiceOrder);
            InvoiceDate = invoice.InvoiceDate;
            PayementDate = invoice.PaymentDate;
            InvoiceUser = new User(invoice.InvoiceUser);
            PaymentStatus = invoice.PaymentStatus;
        }

        public InvoiceDTO ConvertToDTO(Invoice invoice)
        {
            var returnedInvoice = new InvoiceDTO()
            {
                InvoiceNumber = invoice.InvoiceNumber,
                TypeOfInvoice = invoice.TypeOfInvoice,
                InvoiceReference = InvoiceReference.ConvertToDTO(invoice.InvoiceReference),
                InvoiceOrder = InvoiceOrder.ConvertToDTO(invoice.InvoiceOrder),
                InvoiceDate = invoice.InvoiceDate,
                PaymentDate = invoice.PayementDate,
                InvoiceUser = InvoiceUser.ConvertToDTO(invoice.InvoiceUser),
                PaymentStatus = invoice.PaymentStatus
            };
            return returnedInvoice;
        }
    }
}
