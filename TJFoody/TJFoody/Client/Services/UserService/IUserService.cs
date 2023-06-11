namespace TJFoody.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(User user);

        Task<ServiceResponse<string>> Login(User user);

        Task<ServiceResponse<User>> GetUserByPhone(string phone);
    }
}
