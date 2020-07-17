using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly SapoProjectDbContext _context;
        public UserRepository(SapoProjectDbContext context)
        {
            this._context = context;

        }

        public void CreateUser(UserRegister userRegister)
        {
            User user = new User();
            if (userRegister.userPassWord == userRegister.userPassWordAgain && userRegister.userPassWord != null)
            {
                if (!_context.User.Any(i => i.userAccount == userRegister.userAccount))
                {
                    user.userName = userRegister.userName;
                    user.phoneNumber = userRegister.phoneNumber;
                    user.address = userRegister.address;
                    user.age = userRegister.age;
                    user.email = userRegister.email;
                    user.emailReset = userRegister.emailReset;
                    user.userAccount = userRegister.userAccount;
                    user.userPassWord = userRegister.userPassWord;
                    user.status = 1;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteUser(int User)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(int UserID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public void InsertUser(User User)
        {
            throw new NotImplementedException();
        }

        public void LoginUser(string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User UserID)
        {
            throw new NotImplementedException();
        }
    }
}
