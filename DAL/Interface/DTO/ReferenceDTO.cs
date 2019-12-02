using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface.DTO
{
    public class ReferenceDTO
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
    }
}
