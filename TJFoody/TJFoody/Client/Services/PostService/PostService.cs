namespace TJFoody.Client.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly HttpClient _http;
        public PostService(HttpClient http)
        {
            _http = http;
        }
        public List<Post> Posts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<ServiceResponse<int>> addPost(Post post)
        {
            var response = await _http.PostAsJsonAsync("Post/add", post);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
            
        }

        public async Task<ServiceResponse<int>> deletePost(int id)
        {
            var response = await _http.DeleteAsync($"Post/delete/{id}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task getAllPosts()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Post>>>("Post/getAll");
            if(response !=null && response.Data!=null)
            {
                Posts = response.Data;
            }
        }
    }
}
