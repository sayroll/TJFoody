namespace TJFoody.Server.Service.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(string phone,string password,string name);

        Task<bool> UserExists(string phone);

        Task<ServiceResponse<string>> Login(User request);
    }
}
