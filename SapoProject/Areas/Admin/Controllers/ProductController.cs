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
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,Price,OriginalPrice,ShortDescription,EntireDescription,ViewCount")] Product product)
        {
            if (product == null)
            {
                return RedirectToAction(actionName: "NoFound", controllerName: "Share");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productRepository.CreateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return RedirectToAction(actionName: "NoFound", controllerName: "Share");

                }
                return RedirectToAction("GetListProductWithDetail");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult GetListProductWithoutDetail()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                return View(productRepository.GetListProductWithoutDetail());
            }

        }

        // GET: Product
        [HttpGet]
        public ActionResult GetListProductWithDetail()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                return View(productRepository.GetListProductWithDetail());
            }

        }

        // GET: Product/ProductDetailDetails/5
        public ActionResult ProductDetail(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                return View(productRepository.GetProductByID(id));
            }

        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                return View(productRepository.GetProductByID(id));
            }

        }

        //POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Price,OriginalPrice,ShortDescription,EntireDescription,ViewCount")] Product product)
        {

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        productRepository.UpdateProduct(product);
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        return RedirectToAction(actionName: "NoFound", controllerName: "Share");

                    }
                    return RedirectToAction("GetListProductWithDetail");
                }
                else 
                { 
                    return RedirectToAction(actionName: "NoFound", controllerName: "Share"); 
                }
            }

        }
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                if (productRepository.GetProductByID(id) != null)
                {
                    return View(productRepository.GetProductByID(id));
                }
                else
                {
                    return RedirectToAction(actionName: "NoFound", controllerName: "Share");
                }

            }

        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Product product)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        productRepository.DeleteProduct(id);
                        return RedirectToAction(actionName: "GetListProductWithDetail", controllerName: "Product");
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        return RedirectToAction(actionName: "NoFound", controllerName: "Share");

                    }
                }
                else
                {
                    return RedirectToAction(actionName: "NoFound", controllerName: "Share");
                }
            }

        }
    }
}