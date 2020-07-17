using SapoProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Repository.Interface
{
   public interface IUserRepository:IDisposable
    {
        void CreateUser(User User);
        void LoginUser(String userName, String passWord);
        void UpdateUser(User UserID);
        void Save();
    }
}
