using DAL.Interface;
using DAL.Memory;
using DAL.SQLcontext;
using Logic.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ReferenceLogic
    {
        private readonly iReference _context;

        public ReferenceLogic()
        {
            _context = new ReferenceContext();
        }

        public bool AddReference(Reference reference)
        {
            return _context.AddReference(reference.ConvertToDTO(reference));
        }

        public bool RemoveReference(string id)
        {
            return _context.RemoveReference(id);
        }

        public bool EditReference(Reference reference)
        {
            return _context.EditReference(reference.ConvertToDTO(reference));
        }

        public List<Reference> GetReference()
        {
            var collectedReferences = _context.GetReference().ConvertAll(x => new Reference { ID = x.ID, CompanyName = x.CompanyName, ContactName = x.ContactName, Address = x.Address, Zipcode = x.Zipcode, Place = x.Place, Country = x.Country, PhoneNumber = x.PhoneNumber, Email = x.Email, Bank = x.Bank, BIC = x.BIC, IBAN = x.IBAN, KvK = x.KvK, VAT = x.VAT, Doubtfull = x.Doubtfull, Date = x.Date, Note = x.Note });
            return collectedReferences.OrderBy(x => x.CompanyName).ThenBy(x => x.ContactName).ToList();
        }

        public Reference GetReferenceByID(string id)
        {
            return new Reference(_context.GetReferenceByID(id));
        }

        public bool ReferenceCheck(string id)
        {
            return _context.CheckReference(id);
        }
    }
}
