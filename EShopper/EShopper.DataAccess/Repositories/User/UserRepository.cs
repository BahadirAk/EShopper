using EShopper.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EShopper.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EShopperContext _context;
        public UserRepository()
        {
            _context = new EShopperContext();
        }

        public User Add(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(User entity)
        {
            var user = _context.User.FirstOrDefault(r => r.Id == entity.Id);
            user.IsDeleted = true;
            _context.SaveChanges();
        }

        public User GetById(Guid id)
        {
            return _context.User.FirstOrDefault(r => r.Id == id && r.IsDeleted == false);
        }

        public IQueryable<User> GetList(Expression<Func<User, bool>> expression)
        {
            return _context.User.Where(r => r.IsDeleted == false).Where(expression);
        }

        public User GetUserByNameAndPassword(string userName, string password)
        {
            return _context.User.FirstOrDefault(r => r.IsDeleted == false && r.Username == userName && r.Password == password);
        }

        public User GetUserByExpression(Expression<Func<User, bool>> expression)
        {
            return _context.User.FirstOrDefault(expression);
        }

        public User Update(User entity)
        {
            var user = _context.User.FirstOrDefault(r => r.Id == entity.Id);
            user.IsDeleted = entity.IsDeleted;
            user.Password = entity.Password;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;

            _context.SaveChanges();

            return user;
        }
    }
}
