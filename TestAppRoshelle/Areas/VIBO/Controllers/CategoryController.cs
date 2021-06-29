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
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpsertCategory(int? id)
        {
            Category category = new Category();
           
            TempData["categoryList"] = await _unitOfWork.Category.GetAllAsync(x=>x.IsActive=="Y");
            if (id == 0 || id == null)
            {
                return View(category);
            }
            category = await _unitOfWork.Category.GetAsync(id.GetValueOrDefault());
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    category.IsActive = "Y";
                    await _unitOfWork.Category.AddAsync(category);

                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction("UpsertCategory", "Category", new { area = "VIBO", id = 0 });
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _unitOfWork.Category.GetAsync(id);
            if (category != null)
            {
                category.IsActive = "N";
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
            }

            return RedirectToAction("UpsertCategory", "Category", new { area = "VIBO", id = 0 });
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _unitOfWork.Category.GetAllAsync();
            return Json(new { data = allObj });
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
