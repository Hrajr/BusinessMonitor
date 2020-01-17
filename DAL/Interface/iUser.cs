using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interface.DTO;

namespace DAL.Interface
{
    public interface iUser
    {
        List<UserDTO> GetAllUsers();
        UserDTO Login(UserDTO userDTO);
        UserDTO GetUserInfo(string id);
        bool Registration(UserDTO userDTO);
        bool RemoveUser(string id);
    }
}
