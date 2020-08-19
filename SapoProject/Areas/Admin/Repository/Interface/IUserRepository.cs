
using System;
using SapoProject.Areas.Admin.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SapoProject.Areas.Customer.Models.DTO;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface IUserRepository : IDisposable
    {
         Task<int> CreateUser(UserRegister User);
        int LoginUser(UserLogin userLogin);
      
        int GetUserStatusByUserAccount(string UserAccount);
    }
}
