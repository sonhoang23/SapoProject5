﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class ProductEdit
    {
        public int Id { set; get; }
        public String ProductName { set; get; }
        public String Price { set; get; }
        public String OriginalPrice { set; get; }
        public String ShortDescription { set; get; }
        public String EntireDescription { set; get; }
        public String FilePath { set; get; }
        public int ViewCount { set; get; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { set; get; }
        public DateTime FixedDate { set; get; }
        public IFormFile Photo { set; get; }
        public int Status { set; get; }
    }
}