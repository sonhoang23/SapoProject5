using Microsoft.AspNetCore.Http;
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
    public class SharedRepository : ISharedRepository
    {
        private readonly SapoProjectDbContext _context;

        public SharedRepository(SapoProjectDbContext context)
        {
            _context = context;

        }

        public void Dispose()
        {

        }
        public User getUserLogin()
        {
            User user = new User();
            user.UserAccount = "Hoàng Sơn";
            return user;
        }
    }
}