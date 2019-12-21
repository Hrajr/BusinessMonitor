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
    public class ReferenceController : Controller
    {
        private readonly ReferenceLogic _referenceLogic;
        private ReferenceViewModel model = new ReferenceViewModel();

        public ReferenceController()
        {
            _referenceLogic = new ReferenceLogic();
        }

        [HttpGet]
        [Route("Reference")]
        public IActionResult Reference()
        {
            model.ListOfReferences = GetAllReference();
            return View(model);
        }

        [HttpGet]
        [Route("AddReference")]
        public IActionResult AddReference()
        {
            return View();
        }

        [HttpPost]
        [Route("SubmitReference")]
        public IActionResult SubmitReference(IFormCollection formCollection)
        {
            var test = false;
            var newReference = new Reference
            {
                CompanyName = formCollection["CompanyName"],
                ContactName = formCollection["ContactName"],
                Address = formCollection["Address"],
                Zipcode = formCollection["Zipcode"],
                Place = formCollection["Place"],
                Country = formCollection["Country"],
                PhoneNumber = formCollection["PhoneNumber"],
                Email = formCollection["Email"],
                Bank = formCollection["Bank"],
                BIC = formCollection["BIC"],
                IBAN = formCollection["IBAN"],
                KvK = formCollection["KvK"],
                VAT = formCollection["VAT"],
                Doubtfull = Convert.ToBoolean(formCollection["Doubtfull"]),
                Date = DateTime.Now,
                Note = formCollection["Note"],
            };
            if (test)
            { return View("AddReference"); }
            return RedirectToAction("Reference");
        }

        [HttpPost]
        public IActionResult SaveReference(string id, string companyname, string contactname, string address, string zipcode, string place, string country, string phone, string email, string kvk, string vat, string bank, string iban, string bic, string note, bool doubtfull)
        {
            var reference = new Reference()
            {
                ID = id,
                CompanyName = companyname,
                ContactName = contactname,
                Address = address,
                Zipcode = zipcode,
                Place = place,
                Country = country,
                PhoneNumber = phone,
                Email = email,
                KvK = kvk,
                VAT = vat,
                Bank = bank,
                BIC = bic,
                IBAN = iban,
                Note = note,
                Doubtfull = doubtfull
            };
            if (_referenceLogic.EditReference(reference))
            { return View("EditReference"); }
            return View("Reference");
        }

        [HttpGet]
        [Route("EditReference")]
        public IActionResult EditReference(string id)
        {
            var item = new ReferenceViewModel()
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
                Doubtfull = false,
                Note = "He didn't payed for 3 years!"
            };
            return View("EditReference", item);
        }

        [HttpPost]
        public IActionResult RemoveReference(string id)
        {
            _referenceLogic.RemoveReference(id);
            return View("Reference");
        }

        public List<Reference> GetAllReference()
        {
            return _referenceLogic.GetReference();
        }
    }
}