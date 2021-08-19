using EShopper.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EShopper.DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        User GetUserByNameAndPassword(string userName, string password);
        User GetUserByExpression(Expression<Func<User, bool>> expression);
    }
}
