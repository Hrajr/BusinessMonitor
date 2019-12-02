using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface.DTO;

namespace DAL.Interface
{
    public interface iInvoice
    {
        List<InvoiceDTO> GetInvoice();
        InvoiceDTO GetInvoiceByID(string id);
        bool EditInvoice(InvoiceDTO invoice);
        bool RemoveInvoice(string id);
        bool AddInvoice(InvoiceDTO invoice);
    }
}
