using SapoProject.Areas.Customer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Repository.Interface
{
    public interface IProductCustomerRepository : IDisposable
    {
        public int GetOrderIdByClientId(int clientId);
        int CheckOrderClient(int clientId);
        public int CreateOrderClientByClientId(int clientId);
        void Save();
        void Dispose();
        void UpdateOrderDetail(int orderClientId, ProductAddToOrder product);
        List<ProductShowOrderDetail> GetProductShowOrderDetail(int clientId);
        void ApprovalOrder(int clientId, int OrderId);
    }
}
