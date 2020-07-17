using SapoProject.Areas.Admin.Models.Entities;
using System;
using SapoProject.Areas.Admin.Models.DTO;

namespace SapoProject.Areas.Admin.Repository.Interface
{
   public interface IUserRepository:IDisposable
    {
        void CreateUser(UserRegister User);
        void LoginUser(String userName, String passWord);
        void UpdateUser(User UserID);
        void Save();
    }
}
