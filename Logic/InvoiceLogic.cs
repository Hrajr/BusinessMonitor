using DAL.Interface;
using DAL.Memory;
using DAL.SQLcontext;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class InvoiceLogic : ING
    {
        private readonly iInvoice _context;
        private readonly ReferenceLogic _referenceLogic;
        private readonly UserLogic _userLogic;
        private readonly OrderList _orderlist;

        public InvoiceLogic()
        {
            _context = new InvoiceContext();
            _referenceLogic = new ReferenceLogic();
            _userLogic = new UserLogic();
            _orderlist = new OrderList();
        }

        public bool AddInvoice(Invoice invoice)
        {
            invoice.InvoiceNumber = invoicenumber;
            invoice.InvoiceOrder.AddOrderlist(invoicenumber, invoice.InvoiceOrder);
            invoice.InvoiceReference = _referenceLogic.GetReferenceByID(invoice.InvoiceReference.ID);
            return _context.AddInvoice(invoice.ConvertToDTO(invoice));
        }

        public bool RemoveInvoice(string id)
        {
            if (_context.RemoveInvoice(id))
            {
                _orderlist.DeleteOrder(id);
                return true;
            }
            else return false;
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
            //returnedInvoice.InvoiceReference = _referenceLogic.GetReferenceByID(returnedInvoice.InvoiceReference.ID);
            returnedInvoice.InvoiceUser = _userLogic.GetUserByID(returnedInvoice.InvoiceUser.ID);
            returnedInvoice.InvoiceOrder = returnedInvoice.InvoiceOrder.GetOrderByID(returnedInvoice.InvoiceOrder.OrderID);
            return returnedInvoice;
        }
    }
}
