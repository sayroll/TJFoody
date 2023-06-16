namespace TJFoody.Client.Services.CommentService
{
    public interface ICommentService
    {
        Task<List<Comment>> getCommentByPost(int id);
        Task<ServiceResponse<int>> addComment(Comment comment);
        Task<ServiceResponse<int>> deleteComment(int id);

    }
}
