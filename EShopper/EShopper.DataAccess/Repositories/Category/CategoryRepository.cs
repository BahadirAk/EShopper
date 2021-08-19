using EShopper.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EShopper.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EShopperContext _context;
        public CategoryRepository()
        {
            _context = new EShopperContext();
        }

        public Category Add(Category entity)
        {
            _context.Category.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Category entity)
        {
            var category = _context.Category.FirstOrDefault(r => r.Id == entity.Id);
            category.IsDeleted = true;
            category.DeletedDate = entity.DeletedDate;
            category.DeletedUser = entity.DeletedUser;
            _context.SaveChanges();
        }

        public Category GetById(Guid id)
        {
            return _context.Category.FirstOrDefault(r => r.Id == id && r.IsDeleted == false);
        }

        public IQueryable<Category> GetList(Expression<Func<Category, bool>> expression)
        {
            return _context.Category.Where(r => r.IsDeleted == false).Where(expression);
        }

        public Category Update(Category entity)
        {
            var category = _context.Category.FirstOrDefault(r => r.Id == entity.Id);

            category.IsDeleted = entity.IsDeleted;
            category.CategoryName = entity.CategoryName;
            category.UpdatedDate = entity.UpdatedDate;
            category.UpdateUser = entity.UpdateUser;
            category.DeletedDate = entity.DeletedDate;
            category.DeletedUser = entity.DeletedUser;

            _context.SaveChanges();

            return category;
        }

        public Category GetByCategoryName(Category entity)
        {
            return _context.Category.FirstOrDefault(x => x.IsDeleted == false && x.CategoryName == entity.CategoryName && x.CategoryId == entity.CategoryId);
        }
    }
}
