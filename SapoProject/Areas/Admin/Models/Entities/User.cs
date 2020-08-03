using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SapoProject.Models.Entities;
namespace SapoProject.Areas.Admin.Models.Entities
{
    public class User:Person
    {
       public int UserRole{set;get;}
    }
}
