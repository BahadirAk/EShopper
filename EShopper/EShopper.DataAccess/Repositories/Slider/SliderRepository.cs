using EShopper.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EShopper.DataAccess.Repositories
{
    public class SliderRepository : ISliderRepository
    {
        private readonly EShopperContext _context;
        public SliderRepository()
        {
            _context = new EShopperContext();
        }

        public Slider Add(Slider entity)
        {
            _context.Slider.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Slider entity)
        {
            var result = _context.Slider.FirstOrDefault(x => x.Id == entity.Id);
            result.IsDeleted = true;
            _context.SaveChanges();
        }

        public Slider GetById(Guid id)
        {
            return _context.Slider.FirstOrDefault(x => x.IsDeleted == false && x.Id == id);
        }

        public IQueryable<Slider> GetList(Expression<Func<Slider, bool>> expression)
        {
            return _context.Slider.Where(x => x.IsDeleted == false).Where(expression);
        }

        public Slider Update(Slider entity)
        {
            var slider = _context.Slider.FirstOrDefault(r => r.Id == entity.Id);
            slider.IsDeleted = entity.IsDeleted;

            _context.SaveChanges();

            return slider;
        }
    }
}
