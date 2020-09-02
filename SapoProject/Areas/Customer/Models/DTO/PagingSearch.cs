using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Models.DTO
{
    public class PagingSearch
    {
        public int? pageNumber { set; get; }
        public String? searchName { set; get; }
        public String? categoryName { set; get; }



    }
}
