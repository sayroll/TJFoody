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
        public async Task<ServiceResponse<int>> AddComment(int postid, string phone, string content, int? replyId)
        {
            var response = new ServiceResponse<int>();
            response.Data = 100;
            Comment comment = new Comment
            {
                PostId = postid,
                Phone = phone,
                Content = content,
                Time = DateTime.Now.ToString(),
                ReplyId = replyId
            };
            try
            {
                await _infoContext.Comments.AddAsync(comment);
                await _infoContext.SaveChangesAsync();
                response.Message = "数据传输成功";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
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
