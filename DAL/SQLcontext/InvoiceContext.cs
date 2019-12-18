using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public class InvoiceContext : iInvoice
    {
        public bool AddInvoice(InvoiceDTO invoice)
        {
            throw new NotImplementedException();
        }

        public bool EditInvoice(InvoiceDTO invoice)
        {
            throw new NotImplementedException();
        }

        public List<InvoiceDTO> GetInvoice()
        {
            return new List<InvoiceDTO>() { new InvoiceDTO() { InvoiceNumber = "wasda" } };
        }

        public InvoiceDTO GetInvoiceByID(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveInvoice(string id)
        {
            throw new NotImplementedException();
        }
    }
}
