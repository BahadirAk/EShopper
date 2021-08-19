using EShopper.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShopper.DataAccess.Repositories
{
    public interface IProductRepository : IBaseRepository<Product, Guid>
    {
    }
}
