using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SapoProject.Areas.Admin.Models.DTO;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Model.Entities;
namespace SapoProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administration")]
    public class OrderClientController : Controller
    {
        private readonly IOrderClientRepository _orderClientRepository;
        public OrderClientController(IOrderClientRepository orderClientRepository)
        {
            _orderClientRepository = orderClientRepository;
        }
        [HttpGet]
        public ActionResult Index(string orderFilter, string searchString)
        {
            List<OrderClient> orders = new List<OrderClient>();
            if (searchString == null)
            {
                orders = _orderClientRepository.GetOrder();
            }
            else
            {
                orders = _orderClientRepository.GetOrderByFilterAndSearchString(orderFilter, searchString);
            }
            OrderClientFilter orderClientFilter = new OrderClientFilter();

            List<OrderClientShow> orderClientShows = new List<OrderClientShow>();
            for (int index = 0; index < orders.Count(); index++)
            {
                OrderClientShow orderClientShow = new OrderClientShow
                {
                    OrderId = orders[index].OrderId,
                    ClientName = _orderClientRepository.GetClientNameById(orders[index].ClientId),
                    PhoneNumer = _orderClientRepository.GetClientPhoneNumberById(orders[index].ClientId),
                    DateCreated = orders[index].DateCreated,
                    DateCompleted = orders[index].DateCompleted,
                    Status = _orderClientRepository.SwitchStatus(orders[index].Status),
                };
                orderClientShows.Add(orderClientShow);
            }
            orderClientFilter.orderClientShows = orderClientShows;
            orderClientFilter.filter = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem { Selected = true, Text = "Client Name", Value = "ClientName"},
                    new SelectListItem { Selected = false, Text = "Phone Numer", Value = "PhoneNumer"},
                }, "Value", "Text");
            // List<String> filer = orders.R
            return View(orderClientFilter);
        }

        // GET: OrderClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderClientController/Create
        public ActionResult Search()
        {
            return View();
        }

        // POST: OrderClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
