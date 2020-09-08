using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Model.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Model.Entities;
using SapoProject.Areas.Admin.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace SapoProject.Areas.Admin.Repository.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly SapoProjectDbContext _context;
        //private readonly AppSettings _appSettings;
        public UserRepository(SapoProjectDbContext context/*, IOptions<AppSettings> appSettings*/)
        {
            _context = context;
            //_appSettings = appSettings.Value;

        }
        public async Task<int> CreateUser(UserRegister userRegister)
        {
            User user = new User();
            if (userRegister.userPassWord == userRegister.userPassWordAgain && userRegister.userPassWord != null)
            {
                if (!await _context.User.AnyAsync(i => i.UserAccount == userRegister.userAccount))
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
                    await _context.User.AddAsync(user);
                    await _context.SaveChangesAsync();
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

        public int GetUserStatusByUserAccount(string userAccount)
        {
            int userStatus = (from user in _context.User
                              where user.UserAccount == userAccount
                              select user.Status).First();
            return userStatus;
        }

        public int LoginUser(UserLogin userLogin)
        {
            User user = new User();

            var userCheck = _context.User.Where(n => n.UserAccount == userLogin.userAccount && n.UserPassWord == userLogin.userPassWord);
            if (userCheck.Count() > 0)
            {
                //                //Authorization
                //                var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, user.Email),
                //    new Claim("FullName", user.UserName),
                //    new Claim(ClaimTypes.Role, "Admin"),
                //};

                //                var claimsIdentity = new ClaimsIdentity(
                //                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //                var authProperties = new AuthenticationProperties
                //                {
                //                    //AllowRefresh = <bool>,
                //                    // Refreshing the authentication session should be allowed.

                //                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                //                    // The time at which the authentication ticket expires. A 
                //                    // value set here overrides the ExpireTimeSpan option of 
                //                    // CookieAuthenticationOptions set with AddCookie.

                //                    //IsPersistent = true,
                //                    // Whether the authentication session is persisted across 
                //                    // multiple requests. When used with cookies, controls
                //                    // whether the cookie's lifetime is absolute (matching the
                //                    // lifetime of the authentication ticket) or session-based.

                //                    //IssuedUtc = <DateTimeOffset>,
                //                    // The time at which the authentication ticket was issued.

                //                    //RedirectUri = <string>
                //                    // The full path or absolute URI to be used as an http 
                //                    // redirect response value.
                //                };
                //
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
