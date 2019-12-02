﻿using DAL.Interface;
using DAL.SQLcontext;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class InvoiceLogic
    {
        internal readonly iInvoice _context;
        internal readonly iReference _refContext;

        public InvoiceLogic()
        {
            _context = new InvoiceContext();
            _refContext = new ReferenceContext();
        }

        public bool AddInvoice(Invoice invoice, string referenceID, OrderList order)
        {
            OrderList InvoiceOrder = order;
            Reference InvoiceReference = new Reference(_refContext.GetReferenceByID(referenceID));
            return _context.AddInvoice(invoice.ConvertToDTO(invoice));
        }

        public bool RemoveInvoice(string id)
        {
            return _context.RemoveInvoice(id);
        }

        public bool EditInvoice(Invoice invoice)
        {
            return _context.EditInvoice(invoice.ConvertToDTO(invoice));
        }

        public List<Invoice> GetInvoice()
        {
            return _context.GetInvoice().ConvertAll(x => new Invoice { InvoiceNumber = x.InvoiceNumber, TypeOfInvoice = x.TypeOfInvoice, InvoiceReference = new Reference(x.InvoiceReference), InvoiceOrder = new OrderList(x.InvoiceOrder), InvoiceUser = new User(x.InvoiceUser), InvoiceDate = x.InvoiceDate, PayementDate = x.InvoiceDate, PaymentStatus = x.PaymentStatus });
        }

        public Invoice GetInvoiceByID(string id)
        {
            return new Invoice(_context.GetInvoiceByID(id));
        }
    }
}