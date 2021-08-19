using EShopper.Business.Services;
using EShopper.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EShopper.UI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryService.GetCategoryList(null);

            ViewBag.SubCategories = _categoryService.GetSubCategoryList();

            return View();

        }

        [HttpGet]
        public IActionResult AddCategory()
        {



            return View();
        }

        [HttpPost]
        public IActionResult AddCategoryOrSubCategory(CategoryDto model)
        {
            // Update
            if (model.Id != null && model.Id != Guid.Empty)
            {
                // Update
                if (model.CategoryId.HasValue && model.CategoryId.Value != Guid.Empty)
                {
                    // SubCategory Update
                    var result = _categoryService.UpdateSubCategory(model);

                    return Json(result);
                }
                else
                {
                    // Category Update
                    var result = _categoryService.UpdateCategory(model);

                    return Json(result);
                }
            }

            // Add
            if (model.CategoryId.HasValue && model.CategoryId.Value != Guid.Empty)
            {
                // Alt Kategori Ekleme
                var addSubCategoryResult = _categoryService.AddSubCategory(model);

                return Json(addSubCategoryResult);
            }
            else
            {
                // Ust Kategori Ekleme
                var addCategoryResult = _categoryService.AddCategory(model);

                return Json(addCategoryResult);
            }
        }

        [HttpGet]
        public IActionResult UpdateCategoryOrSubCategory(Guid id)
        {
            ViewBag.Categories = _categoryService.GetCategoryList(null);
            var result = _categoryService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryDto model)
        {

            var updateResult = _categoryService.UpdateCategory(model);

            return RedirectToAction(nameof(AdminCategoryController.Index), "AdminCategory");
        }

        [HttpPost]
        public IActionResult UpdateSubCategory(CategoryDto model)
        {

            var result = _categoryService.UpdateSubCategory(model);

            return RedirectToAction(nameof(AdminCategoryController.Index), "AdminCategory");
        }

        [HttpGet]
        public IActionResult DeleteCategoryOrSubCategory(Guid id)
        {
            var result = _categoryService.DeleteCategoryOrSubCategory(id);

            return Json(result);
        }

    }
}