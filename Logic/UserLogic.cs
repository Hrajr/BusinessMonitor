using DAL.Interface;
using DAL.SQLcontext;
using Logic.Encryption;
using Logic.Hasher;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class UserLogic
    {
        private readonly iUser _context;
        private static readonly Hash Hashing = new Hash();
        private static readonly Encryptor Crypto = new Encryptor();
        private User currentUser;

        public UserLogic()
        {
            currentUser = new User();
            _context = new UserContext();
        }

        public bool Login(User user)
        {
            bool Success = false;
            string Input = user.Password;

            user = new User(_context.Login(user.ConvertToDTO(user)));
            currentUser.ID = user.ID;
            currentUser.Admin = user.Admin;
            if (user.ID != null)
            {
                user.Password = Hashing.GetHash(Input, user.Salt);

                if (HashValid(Input, user.Salt, user.Password))
                {
                    Success = true;
                }
            }
            return Success;
        }

        public string MyID()
        {
            return currentUser.ID;
        }

        public bool AdminCheck()
        {
            return currentUser.Admin;
        }

        private static bool HashValid(string Input, string Salt, string Password)
        {
            return Hashing.Validate(Input, Salt, Password);
        }

        public User GetUserByID(string id)
        {
            var user = new User(_context.GetUserInfo(id));
            user = InfoDecryptor(user);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return currentUser.ConvertListOfUsers(_context.GetAllUsers().OrderBy(x => x.Username).ThenBy(x => x.UserID).ToList());
        }

        public bool Registration(User user)
        {
            user = HashUser(user);
            user = InfoEncryptor(user);
            return _context.Registration(user.ConvertToDTO(user));
        }

        public bool RemoveUser(string id)
        {
            return _context.RemoveUser(id);
        }

        private User InfoEncryptor(User user)
        {
            user.Firstname = Crypto.Encrypt(user.Firstname);
            user.Lastname = Crypto.Encrypt(user.Lastname);
            user.Address = Crypto.Encrypt(user.Address);
            user.Zipcode = Crypto.Encrypt(user.Zipcode);
            user.Place = Crypto.Encrypt(user.Place);
            user.Phone = Crypto.Encrypt(user.Phone);
            user.Email = Crypto.Encrypt(user.Email);
            return user;
        }

        private User InfoDecryptor(User user)
        {
            user.Firstname = Crypto.Decrypt(user.Firstname);
            user.Lastname = Crypto.Decrypt(user.Lastname);
            user.Address = Crypto.Decrypt(user.Address);
            user.Zipcode = Crypto.Decrypt(user.Zipcode);
            user.Place = Crypto.Decrypt(user.Place);
            user.Phone = Crypto.Decrypt(user.Phone);
            user.Email = Crypto.Decrypt(user.Email);

            //GET FIELD NAME AND VALUE!!!
            //FieldInfo[] fields = user.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            //for (int i = 0; i < fields.Length; i++)
            //{
            //    var FieldValue = fields[i].GetValue(user).ToString();
            //    string FullFieldName = fields[i].Name;
            //    string TrimmedFieldName = FullFieldName.Remove(FullFieldName.IndexOf('>')).Substring(FullFieldName.IndexOf('<') + 1);
            //}

            return user;
        }

        private User HashUser(User user)
        {
                user.Salt = GetSalt();
                user.Password = Hashing.GetHash(user.Password, user.Salt);
            return user;
        }

        private static string GetSalt()
        {
            return Hashing.Salt;
        }
    }
}
