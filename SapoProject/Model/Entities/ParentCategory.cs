using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Entities
{
    public class ParentCategory
    {
        public int CategoryId { set; get; }
        public String CategoryName { set; get; }
        public string ShortDescription { set; get; }
        public int SortOrder { set; get; }
        public int IsShowOnHome { set; get; }
        public int ParentId { set; get; }
        public String imageURL { set; get; }
        public int Status { set; get; }
    }
}
