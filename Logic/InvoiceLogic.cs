using DAL.Interface;
using DAL.Memory;
using DAL.SQLcontext;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class InvoiceLogic
    {
        private readonly iInvoice _context;
        private readonly ReferenceLogic _referenceLogic;
        private readonly UserLogic _userLogic;
        private readonly OrderList _orderlistLogic;

        public InvoiceLogic()
        {
            _context = new InvoiceContext();
            _referenceLogic = new ReferenceLogic();
            _userLogic = new UserLogic();
            _orderlistLogic = new OrderList();
        }

        public bool AddInvoice(Invoice invoice)
        {
            invoice.InvoiceReference = _referenceLogic.GetReferenceByID(invoice.InvoiceReference.ID);
            return _context.AddInvoice(invoice.ConvertToDTO(invoice));
        }

        public bool RemoveInvoice(string id)
        {
            return _context.RemoveInvoice(id);
        }

        public bool EditInvoice(Invoice invoice)
        {
            invoice.InvoiceReference = _referenceLogic.GetReferenceByID(invoice.InvoiceReference.ID);
            return _context.EditInvoice(invoice.ConvertToDTO(invoice));
        }

        public List<Invoice> GetInvoice()
        {
            return _context.GetInvoice().ConvertAll(x => new Invoice { InvoiceNumber = x.InvoiceNumber, TypeOfInvoice = x.TypeOfInvoice, InvoiceReference = new Reference(x.InvoiceReference), InvoiceOrder = new OrderList(x.InvoiceOrder), InvoiceUser = new User(x.InvoiceUser), InvoiceDate = x.InvoiceDate, PayementDate = x.InvoiceDate, PaymentStatus = x.PaymentStatus });
        }

        public Invoice GetInvoiceByID(string id)
        {
            var returnedInvoice = new Invoice(_context.GetInvoiceByID(id));
            returnedInvoice.InvoiceReference = _referenceLogic.GetReferenceByID(returnedInvoice.InvoiceReference.ID);
            returnedInvoice.InvoiceUser = _userLogic.GetUserByID(returnedInvoice.InvoiceUser.ID);
            returnedInvoice.InvoiceOrder = _orderlistLogic.GetOrderByID(returnedInvoice.InvoiceOrder.OrderID);
            return returnedInvoice;
        }
    }
}
