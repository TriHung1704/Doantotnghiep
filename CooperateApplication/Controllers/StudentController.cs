using CooperateApplication.Service.Model;
using CooperateApplication.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CooperateApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IStudentService _studentService;

        public StudentController(IFileService fileService, IStudentService studentService)
        {
            _fileService = fileService;
            _studentService = studentService;
        }
        [Route("cv")]
        [HttpGet]
        public async Task<IActionResult> GetFileCvAsync()
        {
            var file = await _studentService.CvStudent();
            return Ok(file);
        }
        
        [Route("apply-cv/{page}")]
        [HttpGet]
        public async Task<IActionResult> GetApplyCvAsync(int page)
        {
            var result = await _studentService.GetPostStudentAsync(page);
            return Ok(result);
        }

        [Route("recruitment-cv/{id}")]
        [HttpPost]
        public async Task<IActionResult> RecruitmentCV(int id)
        {
            var result = await _studentService.RecruitmentCV(id);
            return Ok(result);
        }

        [Route("cancel-cv/{id}")]
        [HttpPost]
        public async Task<IActionResult> CancelCV(int id)
        {
            var result = await _studentService.CancelCV(id);
            return Ok(result);
        }

        [Route("my-senimar-attend/{page}")]
        [HttpGet]
        public async Task<IActionResult> GetSenimarAttendAsync(int page)
        {
            var result = await _studentService.GetSenimarAttendAsync(page);
            return Ok(result);
        }

        [Route("senimar-attend/{id}")]
        [HttpPost]
        public async Task<IActionResult> SenimarAttend(int id)
        {
            var result = await _studentService.SenimarAttend(id);
            return Ok(result);
        }

        [Route("cancel-senimar-attend/{id}")]
        [HttpPost]
        public async Task<IActionResult> CancelSenimarAttend(int id)
        {
            var result = await _studentService.CancelSenimarAttend(id);
            return Ok(result);
        }

        [Route("cv/upload-file")]
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var fileName = "cv_" + Guid.NewGuid();
            var fileNameCurrent = "";
            var uploadDirecotroy = "Uploads/CV/";
            var imageURL = await _fileService.UploadFile(file, fileName, fileNameCurrent, uploadDirecotroy);
            var result = await _studentService.UploadCvStudent(imageURL);
            return Ok(result);
        }
    }
}
