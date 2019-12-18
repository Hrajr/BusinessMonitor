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
        private readonly InvoiceLogic _invoiceLogic;
        private InvoiceViewModel model = new InvoiceViewModel();

        public InvoiceController()
        {
            _invoiceLogic = new InvoiceLogic();
        }

        [HttpGet]
        [Route("Invoice")]
        public IActionResult Invoice()
        {
            //var allInvoices = _invoiceLogic.GetInvoice();
            //model.ListOfInvoices.AddRange(allInvoices);
            //return View(model);
            var a = _invoiceLogic.GetInvoice();
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
            var deserializedOrderlist = new List<OrderViewModel>();
            foreach (var item in orderlist)
            {
                var deserializedItem = JsonConvert.DeserializeObject<OrderViewModel>(item);
                deserializedOrderlist.Add(deserializedItem);
            }
            var collectedInformation = new Invoice(id, referenceID, invoiceType, userID, invoiceDate, paymentDate, Convert.ToBoolean(paymentStatus));
            return View();
        }

        [HttpPost]
        [Route("SubmitInvoice")]
        public IActionResult SubmitInvoice(IFormCollection formCollection)
        {
            if (!ModelState.IsValid)
            { return View("AddInvoice"); }
            var newInvoice = new InvoiceViewModel
            {
                //CompanyName = formCollection["CompanyName"],
                //ContactName = formCollection["ContactName"],
                //Address = formCollection["Address"],
                //Zipcode = formCollection["Zipcode"],
                //Place = formCollection["Place"],
                //Country = formCollection["Country"],
                //PhoneNumber = formCollection["PhoneNumber"],
                //Email = formCollection["Email"],
                //Bank = formCollection["Bank"],
                //BIC = formCollection["BIC"],
                //IBAN = formCollection["IBAN"],
                //KvK = formCollection["KvK"],
                //VAT = formCollection["VAT"],
                //Doubtfull = Convert.ToBoolean(formCollection["Doubtfull"]),
                //Date = DateTime.Now,
                //Note = formCollection["Note"],
            };
            //if (_invoiceLogic.AddInvoice(newInvoice))
            //{ return View("AddInvoice"); }
            return View("Invoice");
        }

        [HttpPost]
        public IActionResult RemoveInvoice(string id)
        {
            _invoiceLogic.RemoveInvoice(id);
            return RedirectToAction("Invoice");
        }

        [HttpPost]
        [Route("OpenInvoice")]
        public IActionResult OpenInvoice(string id)
        {
            model.SingleInvoice = _invoiceLogic.GetInvoiceByID(id);
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