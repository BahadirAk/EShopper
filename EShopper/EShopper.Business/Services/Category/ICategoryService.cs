using EShopper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShopper.Business.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategoryList(Guid? parentCategoryId);
        List<CategoryDto> GetSubCategoryList();

        string AddCategory(CategoryDto model);
        string UpdateCategory(CategoryDto model);

        string AddSubCategory(CategoryDto model);
        string UpdateSubCategory(CategoryDto model);

        string DeleteCategoryOrSubCategory(Guid id);
        CategoryDto GetById(Guid modelId);
    }
}
