namespace TJFoody.Server.Service.PostService
{
    public interface IPostService
    {
        Task<ServiceResponse<List<Post>>> GetAllPosts();
        Task<ServiceResponse<int>> AddPost(Post post);
        Task<ServiceResponse<int>> DeletePost(int id);
    }
}
