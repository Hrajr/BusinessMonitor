using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Place { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; } = false;
        public string Salt { get; set; }

        public User()
        { }

        public User(string id, string username, string password, string firstname, string lastname, string address, string zipcode, string place, string phone, string email, bool admin, string salt)
        {
            ID = id;
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Zipcode = zipcode;
            Place = place;
            Phone = phone;
            Email = email;
            Admin = admin;
            Salt = salt;
        }

        public User(UserDTO user)
        {
            ID = user.UserID;
            Username = user.Username;
            Password = user.Password;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Address = user.Address;
            Zipcode = user.Zipcode;
            Place = user.Place;
            Phone = user.Phone;
            Email = user.Email;
            Admin = user.Admin;
            Salt = user.Salt;
        }

        public UserDTO ConvertToDTO(User user)
        {
            var convertedUser = new UserDTO()
            {
                UserID = user.ID,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Address = user.Address,
                Zipcode = user.Zipcode,
                Place = user.Place,
                Phone = user.Phone,
                Email = user.Email,
                Admin = user.Admin,
                Salt = user.Salt
            };
            return convertedUser;
        }
    }
}
