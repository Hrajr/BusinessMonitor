﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessMonitor.Models;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessMonitor.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly InvoiceLogic _invoiceLogic;
        private InvoiceViewModel model = new InvoiceViewModel();
        private ReferenceController RefCont = new ReferenceController();
        private ItemController ItemCont = new ItemController();

        public InvoiceController()
        {
            model.ListOfReferences = RefCont.GetAllReference();
            model.ListOfItems = ItemCont.GetAllAvailableItems();
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
        public IActionResult SaveInvoice(string id, string invoiceType, string[] orderlist, string referenceID, DateTime invoiceDate, DateTime paymentDate, string userID, bool paymentStatus, string oldID)
        {
            var collectedInformation = new Invoice(id, referenceID, orderlist, invoiceType, User.Identity.Name, invoiceDate, paymentDate, paymentStatus);
            collectedInformation.InvoiceUser = new User() { ID = User.Identity.Name };
            _invoiceLogic.EditInvoice(oldID ,collectedInformation);
            return RedirectToAction("Invoice");
        }

        [HttpPost]
        public IActionResult SubmitInvoice(string invoiceType, string[] orderlist, string referenceID, DateTime invoiceDate, DateTime paymentDate, string paymentStatus)
        {
            var collectedNewInformation = new Invoice(referenceID, orderlist, invoiceType, invoiceDate, paymentDate, Convert.ToBoolean(paymentStatus));
            collectedNewInformation.InvoiceUser = new User() { ID = User.Identity.Name };
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

        public JsonResult GetReferenceInformation(string id)
        {
            model.InvoiceReference = RefCont.GetReferenceById(id);
            return Json(model);
        }
    }
}