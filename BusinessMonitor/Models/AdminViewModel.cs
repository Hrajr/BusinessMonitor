using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessMonitor.Models
{
    public class AdminViewModel
    {
        public List<UserModel> allUsers = new List<UserModel>();

        public AdminViewModel(List<User> user)
        {
            ListOfUsers(user);
        }

        public class UserModel
        {
            public string UserID { get; set; }
            public string Username { get; set; }

            public UserModel()
            {

            }
        }

        private void ListOfUsers(List<User> user)
        {
            foreach (var item in user)
            {
                allUsers.Add(new UserModel()
                {
                    UserID = item.ID,
                    Username = item.Username
                });
            }
        }
    }
}
