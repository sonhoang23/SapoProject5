using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            _context = context;

        }

        public int CreateUser(UserRegister userRegister)
        {
            User user = new User();
            if (userRegister.userPassWord == userRegister.userPassWordAgain && userRegister.userPassWord != null)
            {
                if (!_context.User.Any(i => i.UserAccount == userRegister.userAccount))
                {
                    user.UserName = userRegister.userName;
                    user.PhoneNumber = userRegister.phoneNumber;
                    user.Address = userRegister.address + "-" + userRegister.district + "-" + userRegister.city + "-" + userRegister.country;
                    user.Age = userRegister.age;
                    user.Sex = userRegister.sex;
                    user.Email = userRegister.email;
                    user.EmailReset = userRegister.emailReset;
                    user.UserAccount = userRegister.userAccount;
                    user.UserPassWord = userRegister.userPassWord;
                    user.Status = 1;
                    _context.User.Add(user);
                    _context.SaveChanges();
                    return 1;
                }
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public void Dispose()
        {
        
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }

    

        public int LoginUser(UserLogin userLogin)
        {
            User user = new User();

            var userCheck = _context.User.Where(n => n.UserAccount == userLogin.userAccount && n.UserPassWord == userLogin.userPassWord);
            if (userCheck.Count() > 0)
            {
                return 1;

            }
            else
            {
                return 0;
            }
        }

        public void Save()
        {
          
        }

        public void UpdateUser(User UserID)
        {
            
        }
    }
}
