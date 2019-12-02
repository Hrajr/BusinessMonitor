using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Memory
{
    public class MockUser
    {
        public UserDTO UserMock = new UserDTO()
        {
            UserID = "TestID",
            Username = "TestUsername",
            Password = "TestPassword",
            Firstname = "TestFirstname",
            Lastname = "TestLastname",
            Address = "TestAdmin",
            Zipcode = "TestZipcode",
            Place = "TestPlace",
            Admin = true
        };
    }
}
