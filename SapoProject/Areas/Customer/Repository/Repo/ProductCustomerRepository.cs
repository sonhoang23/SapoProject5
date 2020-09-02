using SapoProject.Model.Data;
using SapoProject.Areas.Customer.Repository.Interface;
using System;
using SapoProject.Model;
using Microsoft.Data.SqlClient;
using SapoProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using SapoProject.Areas.Customer.Models.DTO;
using System.Linq;
using System.Collections.Generic;

namespace SapoProject.Areas.Customer.Repository.Repo
{
    public class ProductCustomerRepository : IProductCustomerRepository

    {
        private readonly SapoProjectDbContext _context;

        public ProductCustomerRepository(SapoProjectDbContext context)
        {
            _context = context;

        }
        static private string GetConnectionString()
        {
            return ConnectionString.GetConnectionString();

        }
        public int CheckOrderClient(int clientId)
        {
            if (GetOrderIdByClientId(clientId) == 0)
            {
                CreateOrderClientByClientId(clientId);
                return GetOrderIdByClientId(clientId);
            }
            else
            {
                return GetOrderIdByClientId(clientId);
            }

        }
        public int GetOrderIdByClientId(int clientId)
        {
            int orderId;
            String sql = "SELECT OrderId FROM OrderClient where ClientId = @clientId and Status=1";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@clientId", clientId);
                connection.Open();
                // command.ExecuteReader();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        orderId = reader.GetInt32(0);
                        return orderId;
                    }

                }

            }
            return 0;
        }
        public int CreateOrderClientByClientId(int clientId)
        {
            OrderClient orderClient = new OrderClient
            {
                DateCreated = DateTime.Now,

                ClientId = clientId,
                Status = 1,
            };
            _context.Add(orderClient);
            _context.SaveChanges();
            return 1;
        }


        public void Dispose()
        {

        }

        public void Save()
        {
        }

        public void UpdateOrderDetail(int orderClientId, ProductAddToOrder product)
        {
            product.quantity = (0 < 1) ? 1 : 1;

            if (CheckProductInOrderDetail(orderClientId, product.Id) == 1)
            {
                UpdateQuantityProductInOrderDetail(orderClientId, product);
            }
            else
            {
                CreateProductInOrderDetail(orderClientId, product);
            }
        }


        private void CreateProductInOrderDetail(int orderClientId, ProductAddToOrder product)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                Quantity = product.quantity,
                DateCreated = DateTime.Now,
                Status = 1,
                OrderClientId = orderClientId,
                ProductId = product.Id,
            };
            _context.Add(orderDetail);
            _context.SaveChanges();
        }

        private void UpdateQuantityProductInOrderDetail(int orderClientId, ProductAddToOrder product)
        {
            OrderDetail orderDetail = GetOrderDetailByOrderClientIdAndProductId(orderClientId, product.Id);
            orderDetail.Quantity = orderDetail.Quantity + product.quantity;
            _context.Update(orderDetail);
            _context.SaveChanges();
        }

        private OrderDetail GetOrderDetailByOrderClientIdAndProductId(int orderClientId, int productId)
        {
            return _context.OrderDetail.Where(x => x.Status == 1 && x.OrderClientId == orderClientId && x.ProductId == productId).FirstOrDefault();
        }

        public int CheckProductInOrderDetail(int orderClientId, int productId)
        {
            var productOrderDetailCheck = _context.OrderDetail.Where(n => n.OrderClientId == orderClientId && n.ProductId == productId);
            if (productOrderDetailCheck.Count() > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<ProductShowOrderDetail> GetProductShowOrderDetail(int clientId)
        {
            int OrderClient = GetOrderIdByClientId(clientId);
            List<OrderDetail> orderDetails = GetListOrderDetail(OrderClient);
            List<ProductShowOrderDetail> productShowOrderDetailsList = new List<ProductShowOrderDetail>();


            for (int index = 0; index <= orderDetails.Count() - 1; index++)
            {
                Product product = GetProductByID(orderDetails[index].ProductId);

                char[] arr = { '.' };
                String stringPrice = product.Price.Replace(".", "");
                String PriceByQuantity = (Int32.Parse(stringPrice) * orderDetails[index].Quantity).ToString();
                decimal PriceByQuantityDecimal = decimal.Parse(PriceByQuantity);
                decimal a = 120202020;
                ProductShowOrderDetail productShowOrderDetail = new ProductShowOrderDetail
                {
                    Id = orderDetails[index].OrderDetailId,
                    OrderClientId = orderDetails[index].OrderClientId,
                    ProductId = orderDetails[index].ProductId,
                    ProductName = product.ProductName,
                    Price = float.Parse(product.Price),
                    //     PriceByQuantity = String.Format("{0:C}", Int32.Parse(PriceByQuantity)),
                    PriceByQuantity = String.Format("{0:C0}", PriceByQuantityDecimal),
                    FilePath = product.FilePath,
                    Quantity = orderDetails[index].Quantity,
                    DateCreated = orderDetails[index].DateCreated,
                    OrderDetailId = orderDetails[index].OrderDetailId,
                    Status = orderDetails[index].Status,

                };
                productShowOrderDetailsList.Add(productShowOrderDetail);




            }

            return productShowOrderDetailsList;
        }
        public Product GetProductByID(int productID)
        {
            return _context.Product.Find(productID);
        }
        private List<OrderDetail> GetListOrderDetail(int orderClient)
        {
            return _context.OrderDetail.Where(x => x.Status == 1 && x.OrderClientId == orderClient).ToList();
        }

       
        public void ApprovalOrder(int clientId, int OrderId)
        {
            OrderClient orderClient;
            orderClient= _context.OrderClient.Where(x => x.Status == 1 && x.ClientId == clientId).FirstOrDefault();
            orderClient.Status = 2;
            orderClient.DateCompleted = DateTime.Now;
            _context.Update(orderClient);
            _context.SaveChanges();
        }

        public void UpdateQuantityInOrderViewByAjax(int orderClientId, int productId, int quantity)
        {
            OrderDetail orderDetail = GetOrderDetailByOrderClientIdAndProductId(orderClientId, productId);
            orderDetail.Quantity = quantity;
            _context.Update(orderDetail);
            _context.SaveChanges();
        }
    }
}
