using Microsoft.EntityFrameworkCore;
using TJFoody.Server.Models;

namespace TJFoody.Server.Service.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly infoContext _infoContext;
        public CommentService(infoContext infoContext)
        {
            _infoContext = infoContext;
        }
        public async Task<ServiceResponse<int>> AddComment(int postid, string phone, string content, int replyId)
        {
            var response = new ServiceResponse<int>();

            Comment comment = new Comment
            {
                PostId = postid,
                Phone = phone,
                Content = content,
                Time = DateTime.Now.ToString()
            };
            if(replyId.Equals("-1"))
            {
                response.Message = "这是一个回复帖子的评论";
            }
            else
            {
                comment.ReplyId = replyId;
            }
            await _infoContext.Comments.AddAsync(comment);
            await _infoContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<int>> DeleteComment(int id)
        {
            var res = new ServiceResponse<int>();
            Comment c = _infoContext.Comments.FirstOrDefault(p => p.Id == id);
            if(c != null)
            {
                _infoContext.Comments.Remove(c);
                await _infoContext.SaveChangesAsync();
                res.Message = "成功删除";
            }
            else
            {
                res.Message = "没有找到对应的评论，请检查id是否合适";
            }
            return res;
        }

        public async Task<ServiceResponse<List<Comment>>> GetCommentByPost(int postid)
        {
            var res = new ServiceResponse<List<Comment>>();

            res.Data = await _infoContext.Comments.Where(i=>i.PostId == postid).ToListAsync();

            return res;
        }
    }
}
