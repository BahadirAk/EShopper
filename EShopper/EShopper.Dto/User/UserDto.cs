using System;

namespace EShopper.Dto
{
    public class UserDto
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
