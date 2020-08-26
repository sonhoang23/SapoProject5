using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Models.DTO
{
    public class ProductShowOrderDetail
    {
        public int Id { set; get; }
        //Key
        public int OrderClientId { set; get; }
        public int ProductId { set; get; }
        public String ProductName { set; get; }
        public float Price { set; get; }
        public int Quantity { set; get; }
        public String PriceByQuantity { set; get; }
        public String FilePath { set; get; }
        public int OrderDetailId { set; get; }
        public DateTime DateCreated { set; get; }
        public int Status { set; get; }


    }
}
