using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Entities
{
    public class MenuAccessAdmin
    {
        public int Id { set; get; }
        public String MenuAccessName { set; get; }
        public String MenuAccessLink { set; get; }
        public String MenuAccessImageURL { set; get; }
        public String MenuAccessShrotDescription { set; get; }
        public String MenuAccessRole { set; get; }
        public int Status { set; get; }
        // user ID from AspNetUser table.
        public string OwnerID { get; set; }
        public ProductStatus StatusProduct { get; set; }
    }

    public enum ProductStatus
    {
        Submitted,
        Approved,
        Rejected
    }

}