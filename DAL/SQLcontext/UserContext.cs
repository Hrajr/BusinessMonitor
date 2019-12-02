using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public class UserContext : iUser
    {
        public bool AdminCheck(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserInfo(string id)
        {
            throw new NotImplementedException();
        }

        public UserDTO Login(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public bool Registration(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
