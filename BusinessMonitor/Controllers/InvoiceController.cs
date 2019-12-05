using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessMonitor.Models;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessMonitor.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceLogic _invoiceLogic;
        private readonly ReferenceLogic _referenceLogic;
        private readonly UserLogic _userLogic;
        private readonly OrderList _orderlist;
        private InvoiceViewModel model = new InvoiceViewModel();
        public InvoiceController()
        {
            _invoiceLogic = new InvoiceLogic();
            _referenceLogic = new ReferenceLogic();
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
        public IActionResult SaveInvoice(IFormCollection formCollection, OrderList order)
        {
            var newInvoice = new InvoiceViewModel()
            {
                InvoiceNumber = formCollection["Invoicenumber"],
                //InvoiceReference = _referenceLogic.GetReferenceByID(formCollection["ReferenceID"]),
                InvoiceDate = Convert.ToDateTime(formCollection["CompanyName"]),
                PayementDate = Convert.ToDateTime(formCollection["CompanyName"]),
                InvoiceUser = _userLogic.GetUserInfo(formCollection["CompanyName"]),

            };
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
            return View("Invoice");
        }

        [HttpPost]
        [Route("OpenInvoice")]
        public IActionResult OpenInvoice(string id)
        {
            model.SingleInvoice = _invoiceLogic.GetInvoiceByID(id);
            return View("OpenInvoice", model);
        }

        [HttpPost]
        [Route("EditInvoice")]
        public IActionResult EditInvoice(string id)
        {
            model.SingleInvoice = _invoiceLogic.GetInvoiceByID(id);
            return View("EditInvoice", model);
        }
    }
}