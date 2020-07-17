using SapoProject.Models.Data;
using SapoProject.Models.Entities;
using SapoProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Repository.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly SapoProjectDbContext _context;
        public UserRepository(SapoProjectDbContext context)
        {
            this._context = context;

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
