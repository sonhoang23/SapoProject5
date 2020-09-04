using Microsoft.AspNetCore.Mvc.Rendering;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class OrderClientFilter
    {
        public List<OrderClientShow> orderClientShows { get; set; }
        public SelectList filter { get; set; }
        public string orderFilter { get; set; }
        public string SearchString { get; set; }
    }
}
