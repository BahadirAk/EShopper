using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EShopper.DataAccess.Repositories
{
    public interface IBaseRepository<EntityType, IdType>
    {
        EntityType Add(EntityType entity);
        IQueryable<EntityType> GetList(Expression<Func<EntityType, bool>> expression);
        EntityType Update(EntityType entity);
        void Delete(EntityType entity);
        EntityType GetById(IdType id);
    }
}
