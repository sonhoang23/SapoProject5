using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Areas.Admin.Models.DTO;
using Microsoft.EntityFrameworkCore;
using SapoProject.Model.Entities;

namespace SapoProject.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ParentCategoryName = _categoryRepository.GetParentCategoryName();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreate categoryCreate)
        {

            if (ModelState.IsValid)
            {
                if (categoryCreate == null)
                {
                    return RedirectToAction(actionName: "NoFound", controllerName: "Shared");
                }
                else
                {
                    try
                    {
                        await _categoryRepository.CreateCategory(categoryCreate);
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        return RedirectToAction(actionName: "NoFound", controllerName: "Share");

                    }
                    return RedirectToAction("Create");
                }
            }
            else
            {
                ViewBag.ParentCategoryName = _categoryRepository.GetParentCategoryName();
                return View(categoryCreate);
            }
            // return RedirectToAction(actionName: "NoFound", controllerName: "Shared");
        }
        [HttpGet]
        public ActionResult ListAllCategory()
        {
            List<Category> ChildCategorys = _categoryRepository.ListAllChildCategory();
            List<Category> ParentsCategorys = _categoryRepository.ListAllParentCategory();
            ViewBag.ListAllChildCategory = ChildCategorys;
            ViewBag.ListAllParentCategory = ParentsCategorys;
            return View();
        }

        // GET: Product/ProductDetailDetails/5
        [HttpGet]
        public ActionResult DetailCategory(int CategoryId)
        {
            return View(_categoryRepository.GetCategoryByID(CategoryId));
        }
        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {//ViewBag.ParentCategoryName=_categoryRepository.GetCategoryNameById(_categoryRepository.GetParentCategoryIdByChildCategoryId(id));
            ViewBag.ParentCategoryNameEdit = _categoryRepository.GetParentCategoryNameOrderByChildCatgory(id);
            return View(_categoryRepository.GetCategoryEditByID(id));
        }
        //POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEdit categorytEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryRepository.UpdateCategory(categorytEdit);
                    return RedirectToAction(actionName: "GetListProductWithDetail", controllerName: "Product");
                }
                catch (DbUpdateConcurrencyException)
                {

                    return RedirectToAction(actionName: "NoFound", controllerName: "Share");

                }
            }
            else
            {
                ViewBag.ParentCategoryNameEdit = _categoryRepository.GetParentCategoryNameOrderByChildCatgory(categorytEdit.Id);

                return View(categorytEdit);
            }
        }
        // GET: Product/Delete/5
        /*  public ActionResult DeleteCategory(int id)
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
                      await _productRepository.DeleteProduct(id);
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
          }*/
    }
}