using EShopper.Dto;

namespace EShopper.Business.Services
{
    public interface IUserService
    {
        UserDto GetUserByNameAndPassword(string userName, string password);
        string CreateUser(UserCreateDto dto);
    }
}
