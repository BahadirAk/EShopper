using System;
using System.Collections.Generic;

namespace EShopper.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductImage = new HashSet<ProductImage>();
        }

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}
