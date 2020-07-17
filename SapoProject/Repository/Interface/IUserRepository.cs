using SapoProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Repository.Interface
{
   public interface IUserRepository:IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int UserID);
        void InsertUser(User User);
        void DeleteUser(int User);
        void UpdateUser(User UserID);
        void Save();
    }
}
