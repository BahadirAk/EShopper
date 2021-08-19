using EShopper.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EShopper.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EShopperContext _context;
        public ProductRepository()
        {
            _context = new EShopperContext();
        }

        public Product Add(Product entity)
        {
            _context.Product.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Product entity)
        {
            var product = _context.Product.FirstOrDefault(r => r.Id == entity.Id);
            product.IsDeleted = true;
            _context.SaveChanges();
        }

        public Product GetById(Guid id)
        {
            return _context.Product.FirstOrDefault(r => r.Id == id && r.IsDeleted == false);
        }

        public IQueryable<Product> GetList(Expression<Func<Product, bool>> expression)
        {
            return _context.Product.Where(r => r.IsDeleted == false).Where(expression);
        }

        public Product Update(Product entity)
        {
            var product = _context.Product.FirstOrDefault(r => r.Id == entity.Id);
            product.IsDeleted = entity.IsDeleted;

            _context.SaveChanges();

            return product;
        }
    }
}
