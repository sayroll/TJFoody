using TJFoody.Shared;

namespace TJFoody.Client.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _http;
        public CommentService(HttpClient httpClient)
        {
            _http = httpClient;
        }
        public async Task<ServiceResponse<int>> addComment(Comment comment)
        {
            var response = await _http.PostAsJsonAsync("Comment/add", comment);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<int>> deleteComment(int id)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<int>>($"Comment/delete/{id}");
            return response;
        }

        public async Task<List<Comment>> getCommentByPost(int postid)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Comment>>>($"Comment/get/{postid}");
            return response.Data;
        }
    }
}
