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
        private ReferenceController RefCont = new ReferenceController();

        public InvoiceController()
        {
            model.ListOfReferences = RefCont.GetAllReference();
            _invoiceLogic = new InvoiceLogic();
        }

        [HttpGet]
        [Route("Invoice")]
        public IActionResult Invoice()
        {
            model.ListOfInvoices = _invoiceLogic.GetInvoice();
            return View(model);
        }

        [HttpGet]
        [Route("NewInvoice")]
        public IActionResult NewInvoice()
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveInvoice(string id, string invoiceType, string[] orderlist, string referenceID, DateTime invoiceDate, DateTime paymentDate, string userID, string paymentStatus)
        {
            var collectedInformation = new Invoice(id, referenceID, orderlist, invoiceType, userID, invoiceDate, paymentDate, Convert.ToBoolean(paymentStatus));
            _invoiceLogic.EditInvoice(collectedInformation);
            return View();
        }

        [HttpPost]
        public IActionResult SubmitInvoice(string invoiceType, string[] orderlist, string referenceID, DateTime invoiceDate, DateTime paymentDate, string paymentStatus)
        {
            var collectedNewInformation = new Invoice(referenceID, orderlist, invoiceType, invoiceDate, paymentDate, Convert.ToBoolean(paymentStatus));
            _invoiceLogic.AddInvoice(collectedNewInformation);
            return View("Invoice");
        }

        [HttpPost]
        public IActionResult RemoveInvoice(string id)
        {
            _invoiceLogic.RemoveInvoice(id);
            return RedirectToAction("Invoice");
        }

        [HttpGet]
        [Route("EditInvoice")]
        public IActionResult EditInvoice(string id)
        {
            model.SingleInvoice = _invoiceLogic.GetInvoiceByID(id);
            return View("EditInvoice", model);
        }
    }
}