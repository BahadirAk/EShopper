using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShopper.Dto.Product
{
    public class ProductCommonDto
    {
        public ProductCommonDto()
        {
            ProductImages = new List<ProductImageDto>();
        }

        public ProductDto Product { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
        public IFormFile ProductImage { get; set; }
    }
}
