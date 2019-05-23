﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Abstract;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await customerService.GetCustomersAsync();

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]AddCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await customerService.AddCustomerAsync(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await customerService.GetCustomerAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]EditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await customerService.EditCustomerAsync(model);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            await customerService.RemoveCustomerAsync(id);

            var model = await customerService.GetCustomersAsync();
            model.IsCustomerRemoved = true;

            return View("_CustomersList", model);
        }
    }
}