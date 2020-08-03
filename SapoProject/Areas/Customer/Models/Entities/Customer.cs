using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SapoProject.Models.Entities;
namespace SapoProject.Areas.Customer.Models.Entities
{
    public class Customer:Person
    {
       public int CustomerRole{set;get;}
    }
}
