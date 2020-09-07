using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Models.DTO;
using SapoProject.Areas.Customer.Repository.Interface;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;

namespace SapoProject.Areas.Customer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductCustomerRepository _productRepository;
       

        public ProductController(IProductCustomerRepository productRepository) { 
            _productRepository = productRepository;
        }
        [HttpGet]
        public ActionResult Order()
        {
            int clientId = (int)HttpContext.Session.GetInt32("Id");
            //check có order không?
            if (_productRepository.CheckOrderClient(clientId) == 0)
            {
                return RedirectToAction(actionName: "NoHaveOrder", controllerName: "Product");
            }
            else
            {
                List<ProductShowOrderDetail> productShowOrderDetails = _productRepository.GetProductShowOrderDetail(clientId);
                if (productShowOrderDetails.Count != 0)
                {
                    int totalPrice = 0;
                    int totalQuantity = 0;
                    for (int index = 0; index <= productShowOrderDetails.Count - 1; index++)
                    {
                        
                        totalPrice = totalPrice + Int32.Parse(productShowOrderDetails[index].PriceByQuantity.Replace(".", "").Replace("₫", ""));
                        totalQuantity = totalQuantity + productShowOrderDetails[index].Quantity;
                    }
                    ViewBag.productCount = productShowOrderDetails.Count;
                    ViewBag.totalPrice = String.Format("{0:C0}", totalPrice);
                    ViewBag.totalQuantity = totalQuantity;

                    return View(productShowOrderDetails);

                }
                else
                {
                    TempData["Message"] = "Order Is Empty";
                    return View(productShowOrderDetails);
                }
            }
        }

        [HttpPost]
        public ActionResult AddToOrder(ProductAddToOrder product)
        {
            int clientId = (int)HttpContext.Session.GetInt32("Id");
            int OrderClientId = _productRepository.CheckOrderClient(clientId);

            _productRepository.UpdateOrderDetail(OrderClientId, product);
            return RedirectToAction(actionName: "Index", controllerName: "Customer");
        }
        [HttpPost]
        public ActionResult ApprovalOrder()
        {
            int clientId = (int)HttpContext.Session.GetInt32("Id");
            if (_productRepository.CheckOrderClient(clientId) == 0)
            {
                return RedirectToAction(actionName: "NoHaveOrder", controllerName: "Product");
            }
            else
            {
                _productRepository.ApprovalOrder(clientId, _productRepository.GetOrderIdByClientId(clientId));

                return RedirectToAction(actionName: "Index", controllerName: "Customer");
            }
        }
        [HttpGet]
        public ActionResult UpdateQuantityByAjax(int productId, int quantity)
        {
            int clientId = (int)HttpContext.Session.GetInt32("Id");

            //check có order không?
            if (_productRepository.CheckOrderClient(clientId) == 0)
            {
                return RedirectToAction(actionName: "NoHaveOrder", controllerName: "Product");
            }
            else
            {     //có hoặc order mới được tạo
                int orderClientId = _productRepository.GetOrderIdByClientId(clientId);
                //check có sp trong Order Detail không
                if (_productRepository.CheckProductInOrderDetail(orderClientId, productId) == 0)
                {             //nếu không có sp trong orderdetail
                    return RedirectToAction(actionName: "NoHaveOrder", controllerName: "Product");
                }
                else
                {
                    //nếu có sp trong orderdetail
                    _productRepository.UpdateQuantityInOrderViewByAjax(orderClientId, productId, quantity);


                    List<ProductShowOrderDetail> productShowOrderDetails = _productRepository.GetProductShowOrderDetail(clientId);

                    int totalPrice = 0;
                    int totalQuantity = 0;
                    for (int index = 0; index <= productShowOrderDetails.Count - 1; index++)
                    {
                        totalPrice = totalPrice + Int32.Parse(productShowOrderDetails[index].PriceByQuantity.Replace(".", "").Replace("₫", ""));
                        totalQuantity = totalQuantity + productShowOrderDetails[index].Quantity;
                    }
                    ViewBag.productCount = productShowOrderDetails.Count;
                    ViewBag.totalPrice = String.Format("{0:C0}", totalPrice);
                    ViewBag.totalQuantity = totalQuantity;
                    return PartialView("_PartialViewTotalInformationOrderAjax");
                }
            }
        }
        [HttpGet]
        public ActionResult TestAjaxMenu()
        {
            //return PartialView("_PartialView_MenuProduct1");
            return View();
        }

    }
}




