using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Memory
{
    public class MockInvoice
    {
        public static MockReference TestMockReference = new MockReference();
        public static MockOrderlist TestMockOrderList = new MockOrderlist();
        public static MockUser TestMockUser = new MockUser();
        public InvoiceDTO InvoiceMock = new InvoiceDTO
        {
            InvoiceNumber = "TestInvoiceNumber",
            TypeOfInvoice = Invoicetype.Purchase,
            InvoiceReference = TestMockReference.ReferenceMock,
            InvoiceOrder = TestMockOrderList.OrderListMock,
            InvoiceDate = DateTime.Now.Date,
            PaymentDate = DateTime.Now.Date.AddDays(3),
            InvoiceUser = TestMockUser.UserMock,
            PaymentStatus = false
        };
    }
}
