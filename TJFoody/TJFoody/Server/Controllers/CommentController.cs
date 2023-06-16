using Microsoft.AspNetCore.Mvc;
using TJFoody.Server.Service.CommentService;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Comment>>>> getCommentByPostID(int id)
        {
            var response = await _commentService.GetCommentByPost(id);
            if(response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ServiceResponse<int>>> addComment(Comment comment)
        {
            int postid = comment.PostId;
            string phone = comment.Phone;
            string content = comment.Content;
            int? replyId = comment.ReplyId;
            var response = await _commentService.AddComment(postid, phone, content, replyId);
            
            if(response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> deleteComment(int id)
        {
            var response = await _commentService.DeleteComment(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}
