using EShopper.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EShopper.DataAccess.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly EShopperContext _context;
        public ProductImageRepository()
        {
            _context = new EShopperContext();
        }

        public ProductImage Add(ProductImage entity)
        {
            _context.ProductImage.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(ProductImage entity)
        {
            var productImage = _context.ProductImage.FirstOrDefault(r => r.Id == entity.Id);
            productImage.IsDeleted = true;
            productImage.DeletedUser = entity.DeletedUser;
            productImage.DeletedDate = entity.DeletedDate;
            _context.SaveChanges();
        }

        public ProductImage GetById(Guid id)
        {
            return _context.ProductImage.FirstOrDefault(r => r.Id == id && r.IsDeleted == false);
        }

        public IQueryable<ProductImage> GetList(Expression<Func<ProductImage, bool>> expression)
        {
            return _context.ProductImage.Where(r => r.IsDeleted == false).Where(expression);
        }

        public ProductImage Update(ProductImage entity)
        {
            var productImage = _context.ProductImage.FirstOrDefault(r => r.Id == entity.Id);
            productImage.IsDeleted = entity.IsDeleted;

            _context.SaveChanges();

            return productImage;
        }
    }
}
