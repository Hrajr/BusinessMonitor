using DAL.Interface;
using DAL.Interface.DTO;
using DAL.Memory;
using DAL.SQLcontext;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class InvoiceLogic
    {
        private readonly iInvoice _context;
        private readonly ReferenceLogic _referenceLogic;
        private readonly UserLogic _userLogic;
        private readonly ItemLogic _itemLogic;
        private readonly OrderList _orderlist;

        public InvoiceLogic()
        {
            _context = new InvoiceContext();
            _referenceLogic = new ReferenceLogic();
            _userLogic = new UserLogic();
            _itemLogic = new ItemLogic();
            _orderlist = new OrderList();
        }

        public bool AddInvoice(Invoice invoice)
        {
            invoice.InvoiceNumber = GenerateInvoiceNumber(invoice.TypeOfInvoice);
            invoice.InvoiceOrder.AddOrderlist(GenerateInvoiceNumber(invoice.TypeOfInvoice), invoice.InvoiceOrder);
            invoice.InvoiceOrder.OrderItem = _itemLogic.GetPriceOfList(invoice.InvoiceOrder.OrderItem);
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

        public bool EditInvoice(string oldID, Invoice invoice)
        {
            invoice.InvoiceReference = _referenceLogic.GetReferenceByID(invoice.InvoiceReference.ID);
            if (CheckInvoiceNumber(invoice.InvoiceNumber))
            { GenerateInvoiceNumber(invoice.TypeOfInvoice); }
            invoice.InvoiceOrder.OrderItem = _itemLogic.GetPriceOfList(invoice.InvoiceOrder.OrderItem);
            invoice.InvoiceOrder.OrderID = invoice.InvoiceNumber;
            _orderlist.UpdateOrderlist(oldID, invoice.InvoiceOrder.OrderID, invoice.InvoiceOrder);
            return _context.EditInvoice(oldID, invoice.ConvertToDTO(invoice));
        }

        public List<Invoice> GetInvoice()
        {
            var collectedInvoices = _context.GetInvoice().ConvertAll(x => new Invoice { InvoiceNumber = x.InvoiceNumber, TypeOfInvoice = x.TypeOfInvoice, InvoiceReference = new Reference(x.InvoiceReference), InvoiceOrder = new OrderList(x.InvoiceOrder), InvoiceUser = new User(x.InvoiceUser), InvoiceDate = x.InvoiceDate, PayementDate = x.InvoiceDate, PaymentStatus = x.PaymentStatus });
            foreach (var item in collectedInvoices)
            {
                item.InvoiceOrder = _orderlist.GetOrderByID(item.InvoiceNumber);
                item.InvoiceOrder.OrderItem = _itemLogic.GetPriceOfList(item.InvoiceOrder.OrderItem);
                item.TotalPrice = Math.Round(_orderlist.GetTotalPrice(item.InvoiceOrder), 2);
            }
            return collectedInvoices.OrderBy(x => x.PaymentStatus).ThenBy(x => x.PayementDate).ToList();
        }

        public Invoice GetInvoiceByID(string id)
        {
            var returnedInvoice = new Invoice(_context.GetInvoiceByID(id));
            returnedInvoice.InvoiceReference = _referenceLogic.GetReferenceByID(returnedInvoice.InvoiceReference.ID);
            returnedInvoice.InvoiceOrder = returnedInvoice.InvoiceOrder.GetOrderByID(returnedInvoice.InvoiceOrder.OrderID);
            returnedInvoice.InvoiceOrder.OrderItem = _itemLogic.GetPriceOfList(returnedInvoice.InvoiceOrder.OrderItem);
            returnedInvoice.TotalPrice = Math.Round(_orderlist.GetTotalPrice(returnedInvoice.InvoiceOrder), 2);
            return returnedInvoice;
        }

        public string GenerateInvoiceNumber(Invoicetype info)
        {
            var NewInvoiceNumber = info.ToString();
            NewInvoiceNumber = NewInvoiceNumber + ":" + DateTime.Now.ToString("MM:dd:yyyy:HH:mm:ss");
            while (CheckInvoiceNumber(NewInvoiceNumber))
            {
                NewInvoiceNumber = NewInvoiceNumber + "1";
            }
            return NewInvoiceNumber;
        }

        public bool CheckInvoiceNumber(string id)
        {
            return _context.CheckExistingInvoice(id);
        }
    }
}
