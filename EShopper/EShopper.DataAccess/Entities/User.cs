using System;
using System.Collections.Generic;

namespace EShopper.DataAccess.Entities
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmailActivation { get; set; }
        public bool IsDeleted { get; set; }
    }
}
