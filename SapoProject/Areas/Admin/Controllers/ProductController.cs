using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SapoProject.Areas.Admin.Controllers.Interface;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Models.Entities;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Areas.Admin.Repository.Repo;

namespace SapoProject.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreate productCreate)
        {

            if (ModelState.IsValid)
            {
                if (productCreate == null)
                {
                    return RedirectToAction(actionName: "NoFound", controllerName: "Share");
                }
                else
                {
                    try
                    {
                        try
                        {
                            if (productCreate.Photo != null)
                            {
                                _productRepository.CreateProduct(productCreate);
                            }

                        }
                        catch { }

                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        return RedirectToAction(actionName: "NoFound", controllerName: "Share");

                    }
                    return RedirectToAction("GetListProductWithDetail");
                }
            }
            return View(productCreate);
        }

        [HttpGet]
        public ActionResult GetListProductWithoutDetail()
        {
            return View(_productRepository.GetListProductWithoutDetail());
        }

        // GET: /admin/product/GetListProductWithDetail
        [HttpGet]
        public ActionResult GetListProductWithDetail()
        {
            ViewData["Title"] = "Welcom to Product List!";
            return View(_productRepository.GetListProductWithDetail());

        }
        // GET: Product/ProductDetailDetails/5
        public ActionResult ProductDetail(int id)
        {
            return View(_productRepository.GetProductByID(id));
        }
        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(_productRepository.GetProductEditByID(id));

        }
        //POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEdit productEdit)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _productRepository.UpdateProduct(productEdit);
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
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            if (_productRepository.GetProductByID(id) != null)
            {
                return View(_productRepository.GetProductByID(id));
            }
            else
            {
                return RedirectToAction(actionName: "NoFound", controllerName: "Share");
            }

        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Product product)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _productRepository.DeleteProduct(id);
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