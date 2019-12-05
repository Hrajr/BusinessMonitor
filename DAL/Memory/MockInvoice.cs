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
        public InvoiceDTO InvoiceMock1 = new InvoiceDTO
        {
            InvoiceNumber = "TestInvoiceNumber1",
            TypeOfInvoice = Invoicetype.Purchase,
            InvoiceReference = TestMockReference.ReferenceMock2,
            InvoiceOrder = TestMockOrderList.OrderListMock,
            InvoiceDate = DateTime.Now.Date,
            PaymentDate = DateTime.Now.Date.AddDays(3),
            InvoiceUser = TestMockUser.UserMock,
            PaymentStatus = false
        };
        public InvoiceDTO InvoiceMock2 = new InvoiceDTO
        {
            InvoiceNumber = "TestInvoiceNumber2",
            TypeOfInvoice = Invoicetype.Purchase,
            InvoiceReference = TestMockReference.ReferenceMock3,
            InvoiceOrder = TestMockOrderList.OrderListMock,
            InvoiceDate = DateTime.Now.Date,
            PaymentDate = DateTime.Now.Date.AddDays(3),
            InvoiceUser = TestMockUser.UserMock,
            PaymentStatus = false
        };
        public InvoiceDTO InvoiceMock3 = new InvoiceDTO
        {
            InvoiceNumber = "TestInvoiceNumber3",
            TypeOfInvoice = Invoicetype.Purchase,
            InvoiceReference = TestMockReference.ReferenceMock2,
            InvoiceOrder = TestMockOrderList.OrderListMock,
            InvoiceDate = DateTime.Now.Date,
            PaymentDate = DateTime.Now.Date.AddDays(3),
            InvoiceUser = TestMockUser.UserMock,
            PaymentStatus = false
        };
    }
}
