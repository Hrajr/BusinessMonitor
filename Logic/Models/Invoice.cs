using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public InvoiceType TypeOfInvoice { get; set; }
        public Reference InvoiceReference { get; set; }
        public OrderList InvoiceOrder { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PayementDate { get; set; }
        public User InvoiceUser { get; set; }
        public bool PaymentStatus { get; set; } = false;

        private Reference reference = new Reference();
        private OrderList order = new OrderList();
        private User user = new User();

        public Invoice()
        { }

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
                InvoiceReference = reference.ConvertToDTO(invoice.InvoiceReference),
                InvoiceOrder = order.ConvertToDTO(invoice.InvoiceOrder),
                InvoiceDate = invoice.InvoiceDate,
                PaymentDate = invoice.PayementDate,
                InvoiceUser = user.ConvertToDTO(invoice.InvoiceUser),
                PaymentStatus = invoice.PaymentStatus
            };
            return returnedInvoice;
        }
    }
}
