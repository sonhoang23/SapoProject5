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
    public class OrderClientRepository : IOrderClientRepository
    {
        private readonly SapoProjectDbContext _context;
        private readonly IHostEnvironment _hostingEnvironment;

        public OrderClientRepository(SapoProjectDbContext context, IHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        static private string GetConnectionString()
        {
            return ConnectionString.GetConnectionString();
        }
        public List<OrderClient> GetOrder()
        {
            return _context.OrderClient.Where(x => x.Status != 0).ToList();
        }
    }
}
