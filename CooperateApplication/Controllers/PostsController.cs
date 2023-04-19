using CooperateApplication.Repositories.Entities;
using CooperateApplication.Service.Model;
using CooperateApplication.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CooperateApplication.Service.Enum.Enum;

namespace CooperateApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IFileService _fileService;

        public PostsController(IPostService postService, IFileService fileService)
        {
            _postService = postService;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostAsync([FromQuery] PostSearchRequest postSearchRequest)
        {
            var posts = await _postService.PostsAsync(postSearchRequest);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PostAsync(int id)
        {
            var posts = await _postService.PostsAsync(id);
            return Ok(posts);
        }

        [HttpPost("{type}")]
        [Authorize(Roles = "EmployeeHRM")]
        public async Task<IActionResult> PostAsync(PostTypeName type, PostRequest post)
        {
            post.Type = type;
            var posts = await _postService.RegisterPostsAsync(post);
            return Ok(posts);
        }

        [HttpPut("{type}")]
        [Authorize(Roles = "EmployeeHRM")]
        public async Task<IActionResult> UpdateAsync(PostTypeName type, PostRequest post)
        {
            post.Type = type;
            var posts = await _postService.UpdatePostsAsync(post);
            return Ok(posts);
        }

        [HttpPost]
        [Authorize(Roles = "EmployeeHRM, Administrator")]
        [Route("upload-file")]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var fileName = "post_" + Guid.NewGuid();
            var fileNameCurrent = "";
            var uploadDirecotroy = "Uploads/Post/";
            var imageURL = await _fileService.UploadFile(file, fileName, fileNameCurrent, uploadDirecotroy);
            return Ok(imageURL);
        }

        [HttpGet]
        [Authorize(Roles = "EmployeeHRM")]
        [Route("posts-employee")]
        public async Task<IActionResult> PostOfEmployeeAsync([FromQuery] PostTypeName type, [FromQuery] int page, [FromQuery] int limit)
        {
            var posts = await _postService.PostOfEmployeeAsync(type, page, limit);
            return Ok(posts);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "EmployeeHRM")]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
            var posts = await _postService.Delete(id);
            return Ok(posts);
        }


        [Route("posts-enterprises")]
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllPostAsync([FromQuery] int type, [FromQuery] int page, [FromQuery] int limit)
        {
            var posts = await _postService.GetAllPostsAsync(type, page, limit);
            return Ok(posts);
        }
        
        [Route("confirm-post-enterprise")]
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllPostAsync([FromQuery] int id, [FromQuery] bool isConfirm)
        {
            var posts = await _postService.ConfirmPostAsync(id, isConfirm);
            return Ok(posts);
        }
    }
}
