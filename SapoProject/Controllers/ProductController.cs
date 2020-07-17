using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Models.Data;
using SapoProject.Models.Entities;
using SapoProject.Repository.Repo;

namespace SapoProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly SapoProjectDbContext _context;
        ProductRepository productRepository;
        public ProductController(SapoProjectDbContext context)
        {
            this._context = context;
            this.productRepository = new ProductRepository(_context);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(productRepository.GetProducts());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(productRepository.Edit(id));
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,productName,Price,OriginalPrice,shortDescription,entireDescription,ViewCount,DateCreated")] Product product)
        {
            if (id != product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
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


        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
    }
}