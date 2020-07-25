using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository
{
    public class ShareRepository
    {
        private readonly SapoProjectDbContext _context;
        public ShareRepository(SapoProjectDbContext context)
        {
            this._context = context;
        }
        public User GetUserById(int Id)
        {
            return _context.User.Find(Id);
        }
    }
}
