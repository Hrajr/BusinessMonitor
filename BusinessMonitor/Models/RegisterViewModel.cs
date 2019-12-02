using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessMonitor.Models
{
    public class RegisterViewModel
    {
        public string UserID { get; set; }
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The lenght of your username should be between 8 and 50 characters!")]
        [Required(ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The lenght of your password should be between 8 and 50 characters!")]
        [Required(ErrorMessage = "Password field is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a valid phonenumber!")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
        public string Place { get; set; }
        [Required(ErrorMessage = "Please enter a valid phonenumber!")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Your email is required!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid Email!")]
        public string Email { get; set; }
        public bool Admin { get; set; } = false;
        public string Salt { get; set; }

        public string FullName()
        {
            string FullName = Firstname + " " + Lastname;
            return FullName;
        }
    }
}
