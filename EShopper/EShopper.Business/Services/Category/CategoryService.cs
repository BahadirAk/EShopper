using EShopper.Common.Middleware;
using EShopper.DataAccess.Entities;
using EShopper.DataAccess.Repositories;
using EShopper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EShopper.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CurrentUser _currentUser;
        public CategoryService(ICategoryRepository categoryRepository, CurrentUser currentUser)
        {
            _categoryRepository = categoryRepository;
            _currentUser = currentUser;
        }

        public string DeleteCategoryOrSubCategory(Guid id)
        {
            var result = _categoryRepository.GetById(id);

            if (result != null)
            {
                result.IsDeleted = true;
                result.DeletedUser = _currentUser.Id;
                result.DeletedDate = DateTime.Now;

                _categoryRepository.Delete(result);

                return "Silindi";
            }

            return string.Empty;
        }

        public string AddCategory(CategoryDto model)
        {
            var isExist = CheckCategory(model);

            if (isExist)
            {
                return "Aynı kategori isminden zaten var";
            }
            else
            {
                var result = _categoryRepository.Add(new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = model.CategoryName,
                    CreatedDate = DateTime.Now,
                    CreatedUser = _currentUser.Id,
                    IsDeleted = false
                });

                if (result != null)
                {
                    return "Kategori Eklendi";
                }

                return "Kategori eklernek hata oluştu";
            }
        }

        public string UpdateCategory(CategoryDto model)
        {
            var categoryResult = _categoryRepository.GetById(model.Id);

            if (categoryResult != null)
            {
                categoryResult.CategoryName = model.CategoryName;
                categoryResult.UpdatedDate = DateTime.Now;
                categoryResult.UpdateUser = _currentUser.Id;

                _categoryRepository.Update(categoryResult);

                return "Kategori başariyla güncellendi.";
            }

            return "Kategori güncellenırken hata oluştu";
        }

        public string AddSubCategory(CategoryDto model)
        {
            var isExist = CheckSubCategory(model);

            if (isExist)
            {
                return "Aynı alt kategori isminden zaten var.";
            }
            else
            {
                var result = _categoryRepository.Add(new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    CreatedDate = DateTime.Now,
                    CreatedUser = _currentUser.Id,
                    IsDeleted = false
                });

                if (result != null)
                {
                    return "Alt kategori eklendi.";
                }

                return "Alt kategori eklerken hata oluştu";
            }
        }

        public string UpdateSubCategory(CategoryDto model)
        {
            var subCategoryResult = _categoryRepository.GetById(model.Id);

            if (subCategoryResult != null)
            {
                subCategoryResult.CategoryId = model.CategoryId;
                subCategoryResult.CategoryName = model.CategoryName;
                subCategoryResult.UpdatedDate = DateTime.Now;
                subCategoryResult.UpdateUser = _currentUser.Id;

                _categoryRepository.Update(subCategoryResult);

                return "Alt kategori başariyla güncellendi.";
            }

            return "Alt kategori güncellenirken hata oluştu.";
        }

        public List<CategoryDto> GetCategoryList(Guid? parentCategoryId)
        {
            var categoryList = _categoryRepository.GetList(r => r.IsDeleted == false && r.CategoryId == parentCategoryId);

            return categoryList.Select(x => new CategoryDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Id = x.Id
            }).ToList();
        }

        public List<CategoryDto> GetSubCategoryList()
        {
            var subCategoryList = _categoryRepository.GetList(x => x.IsDeleted == false && x.CategoryId.HasValue && x.CategoryId != Guid.Empty).ToList();

            return subCategoryList.Select(x => new CategoryDto
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public bool CheckCategory(CategoryDto categoryDto)
        {
            var categoryResult = _categoryRepository.GetByCategoryName(new Category
            {
                CategoryName = categoryDto.CategoryName
            });

            if (categoryResult != null)
            {
                // Exist
                return true;
            }
            else
            {
                // Not Exist
                return false;
            }

        }

        public bool CheckSubCategory(CategoryDto categoryDto)
        {
            var isExist = _categoryRepository.GetByCategoryName(new Category
            {
                CategoryName = categoryDto.CategoryName,
                CategoryId = categoryDto.CategoryId
            });

            if (isExist != null)
            {
                // Exits
                return true;
            }
            else
            {
                // Not Exist
                return false;
            }

        }

        public CategoryDto GetById(Guid modelId)
        {
            var result = _categoryRepository.GetById(modelId);

            if (result != null)
            {
                return new CategoryDto
                {
                    Id = result.Id,
                    CategoryName = result.CategoryName,
                    CategoryId = result.CategoryId,
                    CreatedDate = result.CreatedDate,
                    CreatedUser = result.CreatedUser,
                    DeletedDate = result.DeletedDate,
                    DeletedUser = result.DeletedUser,
                    IsDeleted = result.IsDeleted,
                    UpdatedDate = result.UpdatedDate,
                    UpdateUser = result.UpdateUser
                };
            }

            return null;
        }
    }
}