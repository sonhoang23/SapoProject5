using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Customer.Models.DTO;
using SapoProject.Areas.Customer.Repository.Interface;
using SapoProject.Model.Entities;
using System;
using System.Collections.Generic;

namespace SapoProject.Areas.Customer.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductCustomerRepository _productRepository;
        public ProductController(IProductCustomerRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public ActionResult Order()
        {
            int clientId = (int)HttpContext.Session.GetInt32("Id");
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
        public ActionResult ApprovalOrder(ProductShowOrderDetail product)
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
    }
}
