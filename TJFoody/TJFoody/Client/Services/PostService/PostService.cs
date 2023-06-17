namespace TJFoody.Client.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly HttpClient _http;
        public PostService(HttpClient http)
        {
            _http = http;
        }
        public List<Post> Posts { get; set; } = new List<Post>();

        public async Task<ServiceResponse<int>> addPost(Post post)
        {
            var response = await _http.PostAsJsonAsync("Post/add", post);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
            
        }

        public async Task<ServiceResponse<int>> deletePost(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<int>>($"Post/delete/{id}");
            return response;
        }

        public async Task getAllPosts()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Post>>>("Post/getAll");
            if(response !=null && response.Data!=null)
            {
                Posts = response.Data;
            }
        }

        public async Task<Post> getPostById(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Post>>($"Post/get/{id}");
            if(response.Success)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
        }
    }
}
