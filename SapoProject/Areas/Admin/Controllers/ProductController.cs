using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapoProject.Areas.Admin.Models.DTO;

using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Model.Entities;

namespace SapoProject.Areas.Admin.Controllers
{
    public class ProductController : BaseController
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
            ViewData["CategoryNameViewBag"] = _productRepository.GetCategoryName();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreate productCreate)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepository.CreateProduct(productCreate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(actionName: "NoFound", controllerName: "Share");
                }
                return RedirectToAction("Index");

            }
            else
            {
                ViewData["CategoryNameViewBag"] = _productRepository.GetCategoryName();
                return View("Create", productCreate);
            }

        }

        [HttpGet]
        public ActionResult GetListProductWithoutDetail()
        {
            return View(_productRepository.GetListProductWithoutDetail());
        }        // GET: /admin/product/Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewData["Title"] = "Danh Sách Các Sản Phẩm";
            return View(await _productRepository.GetListProductWithDetail());
            // return View(_productRepository.GetListProductWithoutDetail());
        }
        // GET: Product/ProductDetailDetails/5
        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            return View(_productRepository.GetProductByID(id));
        }
        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryNameEditViewBag = _productRepository.GetCategoryNameOrderByProductCategory(id);

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
                    await _productRepository.UpdateProduct(productEdit);
                    return RedirectToAction(actionName: "Index", controllerName: "Product");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(actionName: "NoFound", controllerName: "Share");
                }
            }
            else
            {
                ViewBag.CategoryNameEditViewBag = _productRepository.GetCategoryNameOrderByProductCategory(id);
                return View(productEdit);
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
                return RedirectToAction(actionName: "NoFound", controllerName: "Shared");
            }
        }
        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int t)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepository.DeleteProduct(id);
                    return RedirectToAction(actionName: "Index", controllerName: "Product");
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(actionName: "NoFound", controllerName: "Shared");
                }
            }
            else
            {
                return View(_productRepository.GetProductByID(id));
            }
        }
    }
}