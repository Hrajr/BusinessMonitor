using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessMonitor.Models
{
    public class ReferenceViewModel
    {
            public string ID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string Address { get; set; }
            public string Zipcode { get; set; }
            public string Place { get; set; }
            public string Country { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Bank { get; set; }
            public string BIC { get; set; }
            public string IBAN { get; set; }
            public string KvK { get; set; }
            public string VAT { get; set; }
            public bool Doubtfull { get; set; }
            public DateTime Date { get; set; }
            public string Note { get; set; }

        public ReferenceViewModel()
        { }

            public ReferenceViewModel(Reference reference)
            {
                ID = reference.ID;
                CompanyName = reference.CompanyName;
                ContactName = reference.ContactName;
                Address = reference.Address;
                Zipcode = reference.Zipcode;
                Place = reference.Place;
                Country = reference.Country;
                PhoneNumber = reference.PhoneNumber;
                Email = reference.Email;
                Bank = reference.Bank;
                BIC = reference.BIC;
                IBAN = reference.IBAN;
                KvK = reference.KvK;
                VAT = reference.VAT;
                Doubtfull = reference.Doubtfull;
                Date = reference.Date;
                Note = reference.Note;
            }
        
        public List<Reference> ListOfReferences;
    }
}
