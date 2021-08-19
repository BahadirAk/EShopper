using EShopper.Dto;
using EShopper.Dto.Common;
using EShopper.Dto.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace EShopper.Business.Services
{
    public interface IProductProcessService
    {
        string ProductSave(ProductCommonDto productCommonDto);
        ProductCommonDto GetProductForEdit(Guid productId);
        string ProductImagesSave(IList<IFormFile> productImages, Guid productId);
        string RemoveImage(Guid imageId);
        List<ProductDto> GetProducts();
        PagedResult<ProductDto> GetPaged(int page, int pageSize);
        string RemoveProduct(Guid productId);
    }
}
