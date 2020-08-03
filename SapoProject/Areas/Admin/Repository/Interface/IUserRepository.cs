using SapoProject.Areas.Admin.Models.Entities;
using System;
using SapoProject.Areas.Admin.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Interface
{
    public interface IUserRepository : IDisposable
    {
         Task<int> CreateUser(UserRegister User);
        int LoginUser(UserLogin userLogin);
        Task UpdateUser(User UserID);
        int GetUserStatusByUserAccount(string UserAccount);
    }
}
