using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Controllers.Interface
{
    public interface IProductController
    {
        //CREATE
        public ActionResult Create();
        public Task<IActionResult> Create(ProductCreate productCreate);
        //READ
        public ActionResult GetListProductWithoutDetail();
        public ActionResult GetListProductWithDetail();
        public ActionResult ProductDetail(int id);
        //UPDATE
        public ActionResult Edit(int id);
        public Task<IActionResult> Edit(int id, ProductEdit product);
        //DELETE
    }
}
