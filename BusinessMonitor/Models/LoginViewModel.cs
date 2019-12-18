using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessMonitor.Models
{
    public class LoginViewModel
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password field is required!")]
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
