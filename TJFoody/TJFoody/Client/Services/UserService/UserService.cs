using System.Net.Http.Json;

namespace TJFoody.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            string url = $"User/getByPhone/{phone}";
            Console.WriteLine(url);
            var result = await _http.GetFromJsonAsync<ServiceResponse<User>>(url);
            return result.Data;
        }

        public async Task<ServiceResponse<string>> Login(User user)
        {
            var result = await _http.PostAsJsonAsync("User/login", user);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<String>>();

        }

        public async Task<ServiceResponse<User>>  Register(User user)
        {
            var result = await _http.PostAsJsonAsync("User/register", user);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<User>>();
        }

        async Task<ServiceResponse<User>> IUserService.ModifyUserInfo(User user)
        {
            var result = await _http.PostAsJsonAsync("User/modify", user);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<User>>();
        }
    }
}
