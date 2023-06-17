namespace TJFoody.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(string Phone, string Password, string Name);

        Task<ServiceResponse<string>> Login(User user);

        Task<User> GetUserByPhone(string phone);

        Task<ServiceResponse<User>> ModifyUserInfo(User user);
    }
}
