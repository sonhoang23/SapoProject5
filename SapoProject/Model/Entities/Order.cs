﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Entities
{
    public class Order
    {
        public int OrderId { set; get; }
        
        public int Status { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateCompleted { set; get; }

        //User entity
        public int UserId { set; get; }
        public User User { set; get; }

         //OrderDetail
        public List<OrderDetail> OrderDetails { set; get; }

    }
}