using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Model.Entities;
namespace SapoProject.Areas.Admin.Controllers
{
    public class OrderClientController : BaseController
    {
        private readonly IOrderClientRepository _orderClientRepository;
        public OrderClientController(IOrderClientRepository orderClientRepository)
        {
            _orderClientRepository = orderClientRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
           List<OrderClient> orders= _orderClientRepository.GetOrder();
            return View();
        }

        // GET: OrderClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderClientController/Create
        public ActionResult Create()
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
