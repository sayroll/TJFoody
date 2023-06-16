namespace TJFoody.Server.Service.CommentService
{
    public interface ICommentService
    {
        Task<ServiceResponse<int>> AddComment(int postid, string phone, string content,int? replyId);

        Task<ServiceResponse<List<Comment>>> GetCommentByPost(int postid);

        Task<ServiceResponse<int>> DeleteComment(int id);
    }
}
