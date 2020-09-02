using Microsoft.Extensions.Hosting;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Model;
using SapoProject.Model.Data;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Repository.Repo
{
    public class ClientRepository : IClientRepository
    {
        private readonly SapoProjectDbContext _context;
        private readonly IHostEnvironment _hostingEnvironment;

        public ClientRepository(SapoProjectDbContext context, IHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        static private string GetConnectionString()
        {
            return ConnectionString.GetConnectionString();
        }

        public List<Client> GetListClient()
        {
            return _context.Client.Where(x => x.Status != 0).ToList();
        }
    }
}
