using EShopper.Common.Middleware;
using EShopper.DataAccess.Entities;
using EShopper.DataAccess.Repositories;
using EShopper.Dto;
using EShopper.Dto.Common;
using EShopper.Dto.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EShopper.Common.Statics;
using System.Text;

namespace EShopper.Business.Services
{
    public class ProductProcessService : IProductProcessService
    {
        private readonly CurrentUser _currentUser;
        private readonly IProductRepository _productRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public ProductProcessService(IProductRepository productRepository, IProductImageRepository productImageRepository, CurrentUser currentUser, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _currentUser = currentUser;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public string ProductSave(ProductCommonDto productCommonDto)
        {
            if (productCommonDto.Product.Id == Guid.Empty)
            {
                var productResult = _productRepository.Add(new Product
                {
                    CategoryId = productCommonDto.Product.CategoryId,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    CreatedUser = _currentUser.Id,
                    Name = productCommonDto.Product.Name,
                    Description = productCommonDto.Product.Description,
                    Price = productCommonDto.Product.Price,
                    Id = Guid.NewGuid()
                });


            }
            else
            {
                var productEntity = _productRepository.GetById(productCommonDto.Product.Id);
                if (productEntity != null)
                {
                    productEntity.Name = productCommonDto.Product.Name;
                    productEntity.Price = productCommonDto.Product.Price;
                    productEntity.CategoryId = productCommonDto.Product.CategoryId;
                    productEntity.Description = productCommonDto.Product.Description;
                    productEntity.UpdatedDate = DateTime.Now;
                    productEntity.UpdateUser = _currentUser.Id;

                    _productRepository.Update(productEntity);
                }
            }

            return "İşlem Başarılı";
        }

        public string ProductImagesSave(IList<IFormFile> productImages, Guid productId)
        {
            if (productImages.Any())
            {
                foreach (var row in productImages)
                {
                    var imageResult = _productImageRepository.Add(new ProductImage
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        CreatedUser = _currentUser.Id,
                        ImagePath = string.Empty,
                        IsDeleted = false,
                        ProductId = productId
                    });

                    var rootPath = Directory.GetCurrentDirectory() + $"/wwwroot/productImages/";
                    var directoryName = productId.ToString();

                    var newDirectpryPath = rootPath + directoryName;

                    if (Directory.Exists(newDirectpryPath) == false)
                    {
                        Directory.CreateDirectory(newDirectpryPath);
                    }

                    var dbPath = $"/productImages/{productId}/{imageResult.Id}.png";
                    var uploadPath = Directory.GetCurrentDirectory() + "/wwwroot" + dbPath;

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        row.CopyTo(stream);
                    }

                    var pImage = _productImageRepository.GetById(imageResult.Id);
                    pImage.ImagePath = dbPath;
                    _productImageRepository.Update(pImage);
                }
            }

            return "İşlem Başarılı";
        }

        public ProductCommonDto GetProductForEdit(Guid productId)
        {
            var result = new ProductCommonDto();

            var productEntity = _productRepository.GetById(productId);
            var productImages = _productImageRepository.GetList(x => x.IsDeleted == false && x.ProductId == productId).ToList();
            var categoryEntity = _categoryRepository.GetById(productEntity.CategoryId);
            result.Product = new ProductDto
            {
                Id = productEntity.Id,
                IsDeleted = productEntity.IsDeleted,
                CategoryId = productEntity.CategoryId,
                CreatedDate = productEntity.CreatedDate,
                CreatedUser = productEntity.CreatedUser,
                DeletedDate = productEntity.DeletedDate,
                DeletedUser = productEntity.DeletedUser,
                Description = productEntity.Description,
                Name = productEntity.Name,
                Price = productEntity.Price,
                UpdatedDate = productEntity.UpdatedDate,
                UpdateUser = productEntity.UpdateUser,
                ParentCategoryId = categoryEntity.CategoryId.Value
            };



            if (productImages.Any())
            {
                productImages.ForEach((image) =>
                {
                    result.ProductImages.Add(new ProductImageDto
                    {
                        Id = image.Id,
                        IsDeleted = image.IsDeleted,
                        CreatedDate = image.CreatedDate,
                        CreatedUser = image.CreatedUser,
                        DeletedDate = image.DeletedDate,
                        DeletedUser = image.DeletedUser,
                        UpdatedDate = image.UpdatedDate,
                        UpdateUser = image.UpdateUser,
                        ImagePath = image.ImagePath,
                        ProductId = image.ProductId
                    });
                });
            }

            return result;
        }

        public string RemoveImage(Guid imageId)
        {
            var deleteImage = _productImageRepository.GetById(imageId);
            deleteImage.DeletedDate = DateTime.Now;
            deleteImage.DeletedUser = _currentUser.Id;
            _productImageRepository.Delete(deleteImage);

            return "İşlem Başarılı";
        }

        public List<ProductDto> GetProducts()
        {
            var productList = new List<ProductDto>();
            var products = _productRepository.GetList(x => true);
            var newP = GetProductWithProperties(products);
            productList.AddRange(newP);
            return productList;
        }

        private List<ProductDto> GetProductWithProperties(IQueryable<Product> products)
        {
            var productList = new List<ProductDto>();
            foreach (var row in products)
            {
                var pro = new ProductDto();
                pro.Id = row.Id;
                pro.Name = row.Name;
                pro.Price = row.Price;
                pro.UpdatedDate = row.UpdatedDate;
                pro.CreatedDate = row.CreatedDate;

                var subCategory = _categoryRepository.GetById(row.CategoryId);
                pro.SubCategoryName = subCategory.CategoryName;

                var parentCategory = _categoryRepository.GetById(subCategory.CategoryId.Value);
                pro.ParentCategoryName = parentCategory.CategoryName;

                var createUser = _userRepository.GetById(row.CreatedUser);
                pro.CreatedUserName = createUser.FirstName + " " + createUser.LastName;

                if (row.UpdateUser.HasValue)
                {
                    var updateUser = _userRepository.GetById(row.UpdateUser.Value);
                    pro.UpdateUserName = updateUser.FirstName + " " + updateUser.LastName;
                }

                var images = _productImageRepository.GetList(x => x.IsDeleted == false && x.ProductId == row.Id);
                if (images.Any())
                {
                    pro.DefaultImagePath = images.FirstOrDefault().ImagePath;
                }

                productList.Add(pro);
            }

            return productList;
        }

        public PagedResult<ProductDto> GetPaged(int page, int pageSize)
        {
            var pagedResultEntity = _productRepository.GetList(x => true).GetPaged(page, pageSize);

            PagedResult<ProductDto> result = new PagedResult<ProductDto>();
            result.CurrentPage = pagedResultEntity.CurrentPage;
            result.PageCount = pagedResultEntity.PageCount;
            result.PageSize = pagedResultEntity.PageSize;
            result.RowCount = pagedResultEntity.RowCount;

            var products = GetProductWithProperties(pagedResultEntity.Results.AsQueryable());
            products.ForEach((xx) =>
            {
                result.Results.Add(xx);
            });

            return result;
        }

        public string RemoveProduct(Guid productId)
        {
            var selectedId = _productRepository.GetById(productId);
            if (selectedId != null)
            {
                _productRepository.Delete(selectedId);
            }
            return "Product Deleted";
        }
    }
}
