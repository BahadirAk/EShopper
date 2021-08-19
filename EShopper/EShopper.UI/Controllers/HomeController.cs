using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EShopper.Business.Services;
using EShopper.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace EShopper.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IProductProcessService _productProcessService;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public HomeController(ISliderService sliderService, IProductProcessService productProcessService, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _sliderService = sliderService;
            _productProcessService = productProcessService;
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            var ttt = CultureInfo.CurrentCulture;

            var sss = _stringLocalizer["HelloWorld"];
            var sliders = _sliderService.GetList();
            var products = _productProcessService.GetProducts().Take(6).ToList();
            Tuple<List<SliderDto>, List<ProductDto>> commonModel = new Tuple<List<SliderDto>, List<ProductDto>>(sliders, products);

            return View(commonModel);
        }
    }
}