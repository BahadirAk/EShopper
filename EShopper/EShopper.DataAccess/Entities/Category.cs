using System;
using System.Collections.Generic;

namespace EShopper.DataAccess.Entities
{
    public partial class Category
    {
        public Category()
        {
            InverseCategoryNavigation = new HashSet<Category>();
            Product = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Category> InverseCategoryNavigation { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
