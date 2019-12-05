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

        public UserDTO UserMock1 = new UserDTO()
        {
            UserID = "TestID1",
            Username = "TestUsername1",
            Password = "TestPassword1",
            Firstname = "TestFirstname1",
            Lastname = "TestLastname1",
            Address = "TestAdmin1",
            Zipcode = "TestZipcode1",
            Place = "TestPlace1",
            Admin = true
        };

        public UserDTO UserMock2 = new UserDTO()
        {
            UserID = "TestID2",
            Username = "TestUsername2",
            Password = "TestPassword2",
            Firstname = "TestFirstname2",
            Lastname = "TestLastname2",
            Address = "TestAdmin2",
            Zipcode = "TestZipcode2",
            Place = "TestPlace2",
            Admin = true
        };
    }
}
