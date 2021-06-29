﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TestAppRoshelle.DataAccess.Repository.IRepository;
using TestAppRoshelle.Models;
using TestAppRoshelle.Models.ViewModels;

namespace TestAppRoshelle.Areas.VIBO.Controllers
{
    [Area("VIBO")]
    public class ItemProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public ItemProductController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpsertItemProduct(int? id)
        {
            ItemProductVM itemProductVM = new ItemProductVM()
            {
                ItemProduct = new ItemProduct(),
                SupplierList = (await _unitOfWork.Supplier.GetAllAsync()).Select(i => new SelectListItem
                {
                    Text = i.Id + "|" + i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == 0 || id == null)
            {
                return View(itemProductVM);
            }
            //itemProductVM.ItemProduct =  _unitOfWork.ItemProduct.GetAll(x=>x.Id==id);
            return View(itemProductVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertItemProduct(ItemProductVM itemProductVM)
        {
            //if (ModelState.IsValid)
            //{
            //    if (itemProductVM.ItemProduct.Id == 0)
            //    {
            //        await _unitOfWork.ItemProduct.AddAsync(itemProductVM.ItemProduct);

            //    }
            //    else
            //    {
            //        _unitOfWork.Supplier.Update(suppliervm.Supplier);
            //    }
            //    _unitOfWork.Save();
            //    return RedirectToAction("UpsertSupplier", "Supplier", new { area = "BZUS", id = 0 });
            //}
            return View(itemProductVM);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
