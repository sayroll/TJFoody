namespace TJFoody.Server.Service.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(string phone,string password,string name);

        Task<bool> UserExists(string phone);

        Task<ServiceResponse<string>> Login(User request);

        Task<ServiceResponse<User>> GetUserByPhone(string phone);

        Task<ServiceResponse<User>> ModifyUserInfo(User user);

    }
}
