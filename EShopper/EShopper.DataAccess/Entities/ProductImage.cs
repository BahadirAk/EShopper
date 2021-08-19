using System;
using System.Collections.Generic;

namespace EShopper.DataAccess.Entities
{
    public partial class ProductImage
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        public Guid CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; }
    }
}
