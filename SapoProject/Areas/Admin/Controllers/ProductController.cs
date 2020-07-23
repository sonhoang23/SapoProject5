using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Controllers.Interface;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Repo;

namespace SapoProject.Areas.Admin.Controllers
{
    public class ProductController : Controller, IProductController
    {
        private readonly SapoProjectDbContext _context;
        ProductRepository productRepository;
        public ProductController(SapoProjectDbContext context)
        {
            this._context = context;
            this.productRepository = new ProductRepository(_context);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(",productName,Price,OriginalPrice,shortDescription,entireDescription,ViewCount,DateCreated")] Product product)
        {
            if (product == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productRepository.CreateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult SelfCreate()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetListProductWithoutDetail()
        {
            return View(productRepository.GetListProductWithoutDetail());
        }

        // GET: Product
        [HttpGet]
        public ActionResult GetListProductWithDetail()
        {
            return View(productRepository.GetListProductWithDetail());
        }

        // GET: Product/ProductDetailDetails/5
        public ActionResult ProductDetail(int id)
        {
            return View(productRepository.GetProductByID(id));
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(productRepository.Edit(id));
        }

        //POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,productName,Price,OriginalPrice,shortDescription,entireDescription,ViewCount,DateCreated")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productRepository.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction("Index");
            }
            return View(product);
        }
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Deletetest()
        {
          
                return View();
        }
    }
}