using System;
using System.Collections.Generic;
using System.Text;

namespace EShopper.Dto
{
    public class ProductDto
    {
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
        public Guid ParentCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public string CreatedUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string DefaultImagePath { get; set; }
    }
}
