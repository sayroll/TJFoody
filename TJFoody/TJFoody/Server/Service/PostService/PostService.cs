using Microsoft.EntityFrameworkCore;
using TJFoody.Server.Models;

namespace TJFoody.Server.Service.PostService
{
    public class PostService : IPostService
    {
        private readonly infoContext _context;

        public PostService(infoContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<int>> AddPost(Post post)
        {
            var response  = new ServiceResponse<int>();

            try
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
                response.Message = "成功发布帖子";

            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = $"帖子发送失败，原因为:{ex.Message}";

            }
            return response;
        }

        public async Task<ServiceResponse<int>> DeletePost(int id)
        {
            var response = new ServiceResponse<int>();
            try
            {
                Post post = _context.Posts.FirstOrDefault(p => p.Id == id);
                if (post != null)
                {
                    _context.Remove(post);
                    await _context.SaveChangesAsync();
                    response.Message = "成功删除ID对应的帖子";
                }
                else
                {
                    response.Success = false;
                    response.Message = "对应ID的帖子不存在";
                }
            }catch (Exception ex)
            {
                response.Success=false;
                response.Message = $"删除失败，原因是{ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<Post>>> GetAllPosts()
        {
            var response = new ServiceResponse<List<Post>>();

            response.Data = await _context.Posts.ToListAsync();

            return response;
        }
    }
}
