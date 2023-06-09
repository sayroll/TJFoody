namespace TJFoody.Server.Service.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> Register(string phone,string password,string name);


    }
}
