using Microsoft.AspNetCore.Mvc;
using SapoProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Controllers.Interface
{
    public interface IProductController
    {
        //CREATE
        public ActionResult Create();
        public Task<IActionResult> Create(Product product);
        //READ
        public ActionResult GetListProductWithoutDetail();
        public ActionResult GetListProductWithDetail();
        public ActionResult ProductDetail(int id);
        //UPDATE
        public ActionResult Edit(int id);
        public Task<IActionResult> Edit(int id, [Bind("id,productName,Price,OriginalPrice,shortDescription,entireDescription,ViewCount,DateCreated")] Product product);
        //DELETE
    }
}
