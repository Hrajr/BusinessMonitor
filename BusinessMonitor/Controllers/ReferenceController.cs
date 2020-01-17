using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessMonitor.Models;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessMonitor.Controllers
{
    [Authorize]
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
        public IActionResult SubmitReference(string companyname, string contactname, string address, string zipcode, string place, string country, string phone, string email, string kvk, string vat, string bank, string iban, string bic, string note, bool doubtfull)
        {
            var newReference = new Reference()
            {
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
                Date = DateTime.Now,
                Doubtfull = doubtfull
            };
            if (_referenceLogic.AddReference(newReference))
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
                Date = DateTime.Now,
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
            var item = new ReferenceViewModel(GetReferenceById(id));
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

        public Reference GetReferenceById(string id)
        {
            return _referenceLogic.GetReferenceByID(id);
        }
    }
}