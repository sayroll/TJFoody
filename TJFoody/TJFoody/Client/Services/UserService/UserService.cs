namespace TJFoody.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient httpClient)
        {
            _http = httpClient;
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
    }
}
