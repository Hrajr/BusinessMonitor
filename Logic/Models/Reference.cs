using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Reference
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
        ReferenceLogic _logic = new ReferenceLogic();

        public Reference()
        { }

        public Reference(string id, string companyname, string contactname, string address, string zipcode, string place, string country, string phonenumber, string email, string bank, string bic, string iban, string kvk, string vat, bool doubtfull, DateTime date, string note)
        {
            ID = id;
            CompanyName = companyname;
            ContactName = contactname;
            Address = address;
            Zipcode = zipcode;
            Place = place;
            Country = country;
            PhoneNumber = phonenumber;
            Email = email;
            Bank = bank;
            BIC = bic;
            IBAN = iban;
            KvK = kvk;
            VAT = vat;
            Doubtfull = doubtfull;
            Date = date;
            Note = note;
        }

        public Reference(ReferenceDTO reference)
        {
            ID = reference.ID;
            if (_logic.ReferenceCheck(ID))
            {
                ConvertToReference(reference);
            }
            else
            {
                CompanyName = "This Reference has been removed...";
            }
        }

        public ReferenceDTO ConvertToDTO(Reference reference)
        {
            var ReturnedRef = new ReferenceDTO()
            {
                ID = reference.ID,
                CompanyName = reference.CompanyName,
                ContactName = reference.ContactName,
                Address = reference.Address,
                Zipcode = reference.Zipcode,
                Place = reference.Place,
                Country = reference.Country,
                PhoneNumber = reference.PhoneNumber,
                Email = reference.Email,
                Bank = reference.Bank,
                BIC = reference.BIC,
                IBAN = reference.IBAN,
                KvK = reference.KvK,
                VAT = reference.VAT,
                Doubtfull = reference.Doubtfull,
                Date = reference.Date,
                Note = reference.Note,
            };
            return ReturnedRef;
        }

        public void ConvertToReference(ReferenceDTO reference)
        {
            if (reference.CompanyName == null)
            {
                FillEmptyReference(reference);
            }
            else
            {
                FillReference(reference);
            }
        }

        public void FillEmptyReference(ReferenceDTO reference)
        {
            var correspondingReference = _logic.GetReferenceByID(reference.ID);
            CompanyName = correspondingReference.CompanyName;
            ContactName = correspondingReference.ContactName;
            Address = correspondingReference.Address;
            Zipcode = correspondingReference.Zipcode;
            Place = correspondingReference.Place;
            Country = correspondingReference.Country;
            PhoneNumber = correspondingReference.PhoneNumber;
            Email = correspondingReference.Email;
            Bank = correspondingReference.Bank;
            BIC = correspondingReference.BIC;
            IBAN = correspondingReference.IBAN;
            KvK = correspondingReference.KvK;
            VAT = correspondingReference.VAT;
            Doubtfull = correspondingReference.Doubtfull;
            Date = correspondingReference.Date;
            Note = correspondingReference.Note;
        }

        public void FillReference(ReferenceDTO reference)
        {
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
    }
}
