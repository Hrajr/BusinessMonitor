using DAL.Interface.DTO;
using Newtonsoft.Json;
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

        public Invoice(string referenceID, string[] orderList, string invoiceType, DateTime invoiceDate, DateTime paymentDate, bool paymentStatus)
        {
            TypeOfInvoice = (Invoicetype)System.Enum.Parse(typeof(Invoicetype), invoiceType);
            InvoiceReference = new Reference() { ID = referenceID };
            InvoiceOrder = new OrderList() { OrderItem = fillOrderlist(orderList) };
            InvoiceDate = invoiceDate;
            PayementDate = paymentDate;
            PaymentStatus = paymentStatus;
        }

        public Invoice(string invoiceNumber, string referenceID, string[] orderList, string invoiceType, string userID, DateTime invoiceDate, DateTime paymentDate, bool paymentStatus)
        {
            InvoiceNumber = invoiceNumber;
            TypeOfInvoice = (Invoicetype)System.Enum.Parse(typeof(Invoicetype), invoiceType);
            InvoiceReference = new Reference() { ID = referenceID };
            InvoiceOrder = new OrderList() { OrderItem = fillOrderlist(orderList) };
            InvoiceUser = new User() { ID = userID };
            InvoiceDate = invoiceDate;
            PayementDate = paymentDate;
            PaymentStatus = paymentStatus;
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

        private List<Item> fillOrderlist(string[] order)
        {
            var deserializedOrderlist = new List<Item>();
            foreach (var item in order)
            {
                var deserializedItem = JsonConvert.DeserializeObject<Item>(item);
                deserializedOrderlist.Add(deserializedItem);
            }
            return deserializedOrderlist;
        }
    }
}
