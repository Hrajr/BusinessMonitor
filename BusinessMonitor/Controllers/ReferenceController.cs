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
            var allReferences = _referenceLogic.GetReference();
            model.ListOfReferences = allReferences;
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
            if (!ModelState.IsValid)
            { return View("AddReference"); }
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
            if (_referenceLogic.AddReference(newReference))
            { return View("AddReference"); }
            return View("Reference");
        }

        [HttpPost]
        public IActionResult RemoveReference(string id)
        {
            _referenceLogic.RemoveReference(id);
            return View("Reference");
        }

        [HttpPost]
        [Route("OpenReference")]
        public IActionResult OpenReference(string id)
        {
            var openReference = new ReferenceViewModel.SingleReference(_referenceLogic.GetReferenceByID(id));
            return View("OpenReference", openReference);
        }
    }
}