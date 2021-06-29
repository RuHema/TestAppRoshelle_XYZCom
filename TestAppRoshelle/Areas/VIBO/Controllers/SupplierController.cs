using System;
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
    public class SupplierController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpsertSupplier(int? id)
        {
            TempData["supplierList"] = await _unitOfWork.Supplier.GetAllAsync(x => x.IsActive == "Y",includeProperties:"Category");
            SupplierVM suppliervm = new SupplierVM()
            {
                Supplier = new Supplier(),
                CategoryList = (await _unitOfWork.Category.GetAllAsync()).Select(i => new SelectListItem
                {
                    Text = i.Id + "|" + i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == 0 || id == null)
            {
                return View(suppliervm);
            }
           
            suppliervm.Supplier = await _unitOfWork.Supplier.GetAsync(id.GetValueOrDefault());
            return View(suppliervm);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertSupplier(SupplierVM suppliervm)
        {
            
                if (suppliervm.Supplier.Id == 0)
                {
                    suppliervm.Supplier.IsActive = "Y";
                    await _unitOfWork.Supplier.AddAsync(suppliervm.Supplier);

                }
                else
                {
                    _unitOfWork.Supplier.Update(suppliervm.Supplier);
                }
                _unitOfWork.Save();
                return RedirectToAction("UpsertSupplier", "Supplier", new { area = "VIBO", id = 0 });
          
        }




        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Supplier.GetAllAsync();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Supplier.GetAsync(id);
            if (objFromDb == null)
            {
                TempData["Error"] = "Error deleting Supplier";
                return Json(new { success = false, message = "Error while deleting" });
            }

            await _unitOfWork.Supplier.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Supplier successfully deleted";
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion


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
