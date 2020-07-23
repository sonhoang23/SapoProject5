using SapoProject.Areas.Admin.Models.Entities;
using System;
using SapoProject.Areas.Admin.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace SapoProject.Areas.Admin.Repository.Interface
{
   public interface IUserRepository:IDisposable
    {
        int CreateUser(UserRegister User);
        int LoginUser(UserLogin userLogin);
        void UpdateUser(User UserID);
        void Save();
    }
}
