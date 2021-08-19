using EShopper.DataAccess.Entities;
using System;

namespace EShopper.DataAccess.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category, Guid>
    {
        Category GetByCategoryName(Category entity);
    }
}
