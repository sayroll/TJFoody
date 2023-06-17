using Microsoft.AspNetCore.Mvc;
using TJFoody.Server.Service.PostService;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ServiceResponse<int>>> addPost(Post post)
        {
            var response = await _postService.AddPost(post);
            if(response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> deletePost(int id)
        {
            var response = await _postService.DeletePost(id);
            if( response.Success )
            {
                return Ok(response);
            }
            else { return BadRequest(response); }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<ServiceResponse<List<Post>>>> getAllPosts()
        {
            var res = await _postService.GetAllPosts();
            return Ok(res);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<ServiceResponse<Post>>> getPost(int id)
        {
            var res = await _postService.getPost(id);
            if(res.Success)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
