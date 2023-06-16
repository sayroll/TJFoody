namespace TJFoody.Client.Services.PostService
{
    public interface IPostService
    {
        List<Post> Posts { get; set; }
        Task getAllPosts();
        Task<ServiceResponse<int>> addPost(Post post);

        Task<ServiceResponse<int>> deletePost(int id);
    }
}
