using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessMonitor.Models;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessMonitor.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceLogic logic;
        private InvoiceViewModel model = new InvoiceViewModel();

        public InvoiceController()
        {
            logic = new InvoiceLogic();
        }

        [HttpGet]
        [Route("Invoice")]
        public IActionResult Invoice()
        {
            //var allInvoices = _invoiceLogic.GetInvoice();
            //model.ListOfInvoices.AddRange(allInvoices);
            //return View(model);
            var a = logic.GetInvoice();
            var allInvoices = new InvoiceViewModel();
            allInvoices.ListOfInvoices = a;
            return View(allInvoices);
        }

        [HttpGet]
        [Route("NewInvoice")]
        public IActionResult NewInvoice()
        {
            //model.ListOfInvoices.AddRange(_invoiceLogic.GetInvoice());
            //return View(model);
            var a = new InvoiceViewModel();
            return View(a);
        }

        [HttpPost]
        public IActionResult SaveInvoice(string id, string invoiceType, string[] orderlist, string referenceID, DateTime invoiceDate, DateTime paymentDate, string userID, string paymentStatus)
        {
            var collectedInformation = new Invoice(id, referenceID, orderlist, invoiceType, userID, invoiceDate, paymentDate, Convert.ToBoolean(paymentStatus));
            logic.EditInvoice(collectedInformation);
            return View();
        }

        [HttpPost]
        public IActionResult SubmitInvoice(string invoiceType, string[] orderlist, string referenceID, DateTime invoiceDate, DateTime paymentDate, string paymentStatus)
        {
            var collectedNewInformation = new Invoice(referenceID, orderlist, invoiceType, invoiceDate, paymentDate, Convert.ToBoolean(paymentStatus));
            logic.AddInvoice(collectedNewInformation);
            return View("Invoice");
        }

        [HttpPost]
        public IActionResult RemoveInvoice(string id)
        {
            logic.RemoveInvoice(id);
            return RedirectToAction("Invoice");
        }

        [HttpPost]
        [Route("OpenInvoice")]
        public IActionResult OpenInvoice(string id)
        {
            model.SingleInvoice = logic.GetInvoiceByID(id);
            return View("OpenInvoice", model);
        }

        [HttpGet]
        [Route("EditInvoice")]
        public IActionResult EditInvoice(string id)
        {
            var testRef = new Reference()
            {
                ID = "TestID",
                CompanyName = "TestCompany",
                ContactName = "Dirk van den Veen",
                Address = "Exeaten 1",
                Zipcode = "6044 BA",
                Place = "Baexem",
                Country = "The Netherlands",
                KvK = "TestKVK",
                IBAN = "TestIBAN",
                Bank = "ING",
                BIC = "INGB",
                VAT = "VATnum",
                PhoneNumber = "TestPhone",
                Email = "TestEmail",
                Doubtfull = true,
                Note = "He didn't payed for 3 years!"
            };
            var testUser = new User()
            {
                ID = "TestID",
                Username = "TestUsername",
                Password = "TestPassword",
                Firstname = "TestFirstname",
                Lastname = "TestLastname",
                Address = "TestAdmin",
                Zipcode = "TestZipcode",
                Place = "TestPlace",
                Admin = true
            };
            var testItem1 = new Item()
            {
                ItemID = "Test",
                ProductName = "Name",
                Description = "Desc",
                Price = 2,
                VAT = 9,
                Amount = 0,
                InStock = false
            };
            var testItem2 = new Item()
            {
                ItemID = "Test2",
                ProductName = "Name2",
                Description = "Desc2",
                Price = 3,
                VAT = 21,
                Amount = 3,
                InStock = true
            };
            var testItem3 = new Item()
            {
                ItemID = "Test3",
                ProductName = "Name3",
                Description = "Desc3",
                Price = 4,
                VAT = 9,
                Amount = 1,
                InStock = true
            };
            var a = new List<Item>();
            a.Add(testItem1);
            a.Add(testItem2);
            a.Add(testItem3);
            var Order = new OrderList()
            {
                OrderID = "1",
                Amount = 2,
                OrderItem = a
            };
            var Invoice = new InvoiceViewModel()
            {
                InvoiceNumber = "TestInvoiceNumber",
                InvoiceReference = testRef,
                InvoiceUser = testUser,
                InvoiceDate = DateTime.Today.AddDays(1),
                PayementDate = DateTime.Today.AddDays(15),
                InvoiceOrder = Order
            };
            return View("EditInvoice", Invoice);
            //model.SingleInvoice = _invoiceLogic.GetInvoiceByID(id);
            //return View("EditInvoice", model);
        }
    }
}