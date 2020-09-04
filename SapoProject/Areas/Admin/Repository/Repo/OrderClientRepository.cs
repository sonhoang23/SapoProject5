using Microsoft.Extensions.Hosting;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Model;
using SapoProject.Model.Data;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        public string GetClientNameById(int clientId)
        {
            String clientName = (from client in _context.Client
                                 where client.Id == clientId
                                 select client.CustomerName).First();
            return clientName;

        }

        public string GetClientPhoneNumberById(int clientId)
        {
            String phoneNumber = (from client in _context.Client
                                  where client.Id == clientId
                                  select client.PhoneNumber).First();
            return phoneNumber;
        }

        public List<OrderClient> GetOrder()
        {
            return _context.OrderClient.ToList();
        }

        public List<OrderClient> GetOrderByFilterAndSearchString(string orderFilter, String searchString)
        {
            List<OrderClient> orderClients = new List<OrderClient>();
            if (orderFilter == "ClientName")
            {

                List<int> clientIds = (from client in _context.Client
                                       where client.CustomerName.Contains(searchString)
                                       select client.Id).ToList();
                for (int index = 0; index < clientIds.Count(); index++)
                {
                    OrderClient orderClientById = (from orderClient in _context.OrderClient
                                                   where orderClient.ClientId == clientIds[index]
                                                   select orderClient).First();
                    orderClients.Add(orderClientById);
                }

                return orderClients;
            }
            if (orderFilter == "PhoneNumer")
            {
                List<int> clientIds = (from client in _context.Client
                                       where client.PhoneNumber.Contains(searchString)
                                       select client.Id).ToList();
                for (int index = 0; index < clientIds.Count(); index++)
                {
                    OrderClient orderClientById = (from orderClient in _context.OrderClient
                                                   where orderClient.ClientId == clientIds[index]
                                                   select orderClient).First();
                    orderClients.Add(orderClientById);
                }

                return orderClients;
            }
            return _context.OrderClient.ToList();
        }

        private List<Client> GetClientByCustomerName(string orderFilter)
        {
            return _context.Client.Where(x => x.CustomerName.Contains(orderFilter)).ToList();
        }

     

        public string SwitchStatus(int status)
        {
            String switchStatus;

            switch (status)
            {
                case 0:
                    switchStatus = "Đơn Hủy";
                    return switchStatus;
                case 1:
                    switchStatus = "Đang Mua Hàng";
                    return switchStatus;
                case 2:
                    switchStatus = "Đơn Đã Xác Nhận Mua";
                    return switchStatus;
            }
            return switchStatus = "Không Xác Định";

        }
        //public List<String> GetColName()
        //{
        //   List<String> columnNames = _context
        //    return _context.OrderClient.ToList();
        //}
    }
}
