using CooperateApplication.Service.Model;
using CooperateApplication.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CooperateApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;
        private readonly ISlideImageService _slideImageService;
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly INotificationService _notificationService;

        public HomeController(IFileService fileService, ISlideImageService slideImageService, IUserService userService, IStudentService studentService, INotificationService notificationService)
        {
            _fileService = fileService;
            _slideImageService = slideImageService;
            _userService = userService;
            _studentService = studentService;
            _notificationService = notificationService;
        }
        [Route("slide")]
        [HttpGet]
        public async Task<IActionResult> Silde()
        {
            return Ok((await _slideImageService.GetSlideFile()));
        }

        [Route("slide")]
        [HttpPost]
        public async Task<IActionResult> SildeAsync(SlideImageModel slideImageModel)
        {
            var slideImage = await _slideImageService.Insert(slideImageModel.ToEntities());
            return Ok(slideImage);
        }

        [Route("slide/enable/{id}")]
        [HttpPost]
        public async Task<IActionResult> SildeEnableAsync(int id)
        {
            var slideImage = await _slideImageService.EnableSlide(id);
            return Ok(slideImage);
        }
        
        [Route("slide/upload-file")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var fileName = "slide_" + Guid.NewGuid();
            var fileNameCurrent = "";
            var uploadDirecotroy = "Uploads/Sile/";
            var imageURL = await _fileService.UploadFile(file, fileName, fileNameCurrent, uploadDirecotroy);
            return Ok(imageURL);
        }
        
        [Route("student/upload-file")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> StudentAsync(IFormFile file)
        {
            var fileName = "student_" + Guid.NewGuid();
            var fileNameCurrent = "";
            var uploadDirecotroy = "Uploads/Student/";
            var fileUrl = await _fileService.UploadFile(file, fileName, fileNameCurrent, uploadDirecotroy);
            var result = await _userService.CreateUser(fileUrl);
            return Ok(result);
        }
        
        [Route("student/{page}")]
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> StudentAsync(int page)
        {
            var result = await _studentService.GetStudentAsync(page);
            return Ok(result);
        }

        [Route("student/lock-student/{isLock}/{userId}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> LockEmployeeAsync(bool isLock, int userId)
        {
            var result = await _studentService.LockStudent(isLock, userId);
            return Ok(result);
        } 
        
        [Route("posts/notification")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> NotificationAsync(NotificationModel notificationModel)
        {
            var result = await _notificationService.RegisterPostsAsync(notificationModel);
            return Ok(result);
        }
        
        [Route("posts/notifications")]
        [HttpGet]
        public async Task<IActionResult> NotificationAsync([FromQuery] int page, [FromQuery] int number = 6)
        {
            var result = await _notificationService.PostsAsync(page, number);
            return Ok(result);
        }
        
        [Route("posts/notification/{id}")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteNotificationAsync(int id)
        {
            var result = await _notificationService.Delete(id);
            return Ok(result);
        }
        
        [Route("posts/notification/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetNotificationAsync(int id)
        {
            var result = await _notificationService.GetById(id);
            return Ok(result);
        }
        [Route("posts/notification")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateNotificationAsync(NotificationModel notificationModel)
        {
            var result = await _notificationService.UpdateNotiPostsAsync(notificationModel);
            return Ok(result);
        }
    }
}
