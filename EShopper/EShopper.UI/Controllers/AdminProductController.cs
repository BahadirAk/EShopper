using EShopper.Business.Services;
using EShopper.Dto;
using EShopper.Dto.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EShopper.UI.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductProcessService _productProcessService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public AdminProductController(
            ICategoryService categoryService,
            IProductProcessService productProcessService,
            IStringLocalizer<SharedResource> stringLocalizer)
        {
            _categoryService = categoryService;
            _productProcessService = productProcessService;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index(int? page)
        {
            var sss = CultureInfo.CurrentCulture;
            var text = _stringLocalizer["HelloWorld"];
            if (page.HasValue == false || page < 1)
            {
                page = 1;
            }

            //var products = _productProcessService.GetProducts();
            var products = _productProcessService.GetPaged(page.Value, 10);

            return View(products);
        }

        [HttpGet]
        public IActionResult AddOrUpdate(Guid? productId)
        {
            ViewBag.Categories = GetCategories(null);

            if (productId.HasValue && productId.Value != Guid.Empty)
            {
                var result = _productProcessService.GetProductForEdit(productId.Value);
                return View(result);
            }

            return View(new ProductCommonDto());
        }

        public List<CategoryDto> GetCategories(Guid? parentCategoryId)
        {
            return _categoryService.GetCategoryList(parentCategoryId);
        }

        [HttpGet]
        public JsonResult GetSubCategories(Guid parentCategoryId)
        {
            var subCategories = _categoryService.GetCategoryList(parentCategoryId);
            return Json(subCategories);
        }

        [HttpPost]
        public IActionResult ProductSave(ProductCommonDto productCommonDto)
        {
            var result = _productProcessService.ProductSave(productCommonDto);
            return Json(result);
        }

        [HttpPost]
        public IActionResult UploadFiles(IList<IFormFile> productImage, Guid productId)
        {
            var result = _productProcessService.ProductImagesSave(productImage, productId);
            return Json(result);
        }

        [HttpGet]
        public IActionResult RemoveImage(Guid imageId)
        {
            var result = _productProcessService.RemoveImage(imageId);
            return Json(result);
        }

        [HttpGet]
        public IActionResult DeleteProduct(Guid productId)
        {
            var result = _productProcessService.RemoveProduct(productId);
            return Json(result);
        }
    }
}