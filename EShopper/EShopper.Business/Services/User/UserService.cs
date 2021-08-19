using EShopper.DataAccess.Repositories;
using EShopper.Dto;
using System;

namespace EShopper.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto GetUserByNameAndPassword(string userName, string password)
        {
            var user = _userRepository.GetUserByNameAndPassword(userName, password);
            if (user != null)
            {
                return new UserDto
                {
                    EmailAddress = user.EmailAddress,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    IsDeleted = user.IsDeleted,
                    IsEmailActivation = user.IsEmailActivation,
                    LastName = user.LastName,
                    Password = user.Password,
                    Username = user.Username
                };
            }

            return null;
        }

        public string CreateUser(UserCreateDto dto)
        {
            var user = _userRepository.GetUserByExpression(r => r.IsDeleted == false && (r.Username == dto.UserName || r.EmailAddress == dto.EmailAddress));

            if (user != null)
            {
                return "Username or EmailAddress is exist";
            }

            _userRepository.Add(new DataAccess.Entities.User
            {
                EmailAddress = dto.EmailAddress,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsDeleted = false,
                IsEmailActivation = true,
                Password = dto.Password,
                Username = dto.UserName,
                Id = Guid.NewGuid()
            });

            return "Kaydedildi";
        }
    }
}
