using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface.DTO;

namespace DAL.Interface
{
    public interface iUser
    {
        bool CheckUserExists(UserDTO userDTO);
        UserDTO Login(UserDTO userDTO);
        UserDTO GetUserInfo(string id);
        bool Registration(UserDTO userDTO);
    }
}
