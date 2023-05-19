using CooperateApplication.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CooperateApplication.Service.Model;
using static CooperateApplication.Service.Enum.Enum;
using CooperateApplication.Repositories.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CooperateApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : Controller
    {
        private readonly IEnterpriseEmployeeService _enterpriseEmployeeService;
        private readonly IPostService _postService;
        private readonly IFileService _fileService;

        public EnterpriseController(IEnterpriseEmployeeService enterpriseEmployeeService, IPostService postService, IFileService fileService)
        {
            _enterpriseEmployeeService = enterpriseEmployeeService;
            _postService = postService;
            _fileService = fileService;
        }

        [HttpGet]
        [Route("list-enterprise")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ListEnterprisesAsync([FromQuery]int page)
        {
            var enterprises = await _enterpriseEmployeeService.GetListEnterprisesAsync(page);
            return Ok(enterprises);
        }
        
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetEnterprisesAsync([FromQuery]int id)
        {
            var enterprises = await _enterpriseEmployeeService.GetEnterprisesAsync(id);
            return Ok(enterprises);
        }

        [Route("register")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RegisterEnterprisesAsync(EnterpriseModel enterpriseModel)
        {
            var result = await _enterpriseEmployeeService.CreateEnterprise(enterpriseModel);
            return Ok(result);
        }


        [Route("update")]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateEnterpriseAsync(EnterpriseModel enterpriseModel)
        {
            var result = await _enterpriseEmployeeService.UpdateEnterprise(enterpriseModel);
            return Ok(result);
        }

        [Route("lock-enterprise")]
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> LockEnterpriseAsync([FromQuery] bool islock, [FromQuery] int enterpriseId)
        {
            var result = await _enterpriseEmployeeService.LockEnterprise(islock, enterpriseId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, EmployeeAdmin")]
        [Route("upload-file")]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var fileName = "user_" + Guid.NewGuid();
            var fileNameCurrent = "";
            var uploadDirecotroy = "Uploads/Enterprises/";
            var imageURL = await _fileService.UploadFile(file, fileName, fileNameCurrent, uploadDirecotroy);
            return Ok(imageURL);
        }

        [Route("employee")]
        [HttpGet]
        [Authorize(Roles = "EmployeeAdmin")]
        public async Task<IActionResult> EmployeeAsync()
        {
            var userEmployee = await _enterpriseEmployeeService.GetEmployeeAsync();
            return Ok(userEmployee);
        }
        
        [Route("create-employee")]
        [HttpPost]
        [Authorize(Roles = "EmployeeAdmin")]
        public async Task<IActionResult> CreateEmployeeAsync(UserRequest userRequest)
        {
            var userEmployee = await _enterpriseEmployeeService.CreateEmployee(userRequest);
            return Ok(userEmployee);
        }
        
        [Route("lock-employee/{isLock}/{userId}")]
        [HttpDelete]
        [Authorize(Roles = "EmployeeAdmin")]
        public async Task<IActionResult> LockEmployeeAsync(bool isLock, int userId)
        {
            var result = await _enterpriseEmployeeService.LockEmployee(isLock, userId);
            return Ok(result) ;
        }

        [Route("apply-cv")]
        [HttpGet]
        [Authorize(Roles = "EmployeeHRM")]
        public async Task<IActionResult> GetApplyCVAsync([FromQuery] int postId, [FromQuery] int page)
        {
            var result = await _postService.GetPostStudentAsync(postId, page);
            return Ok(result);
        }
        
        [Route("accepted-cv")]
        [HttpPost]
        [Authorize(Roles = "EmployeeHRM")]
        public async Task<IActionResult> AcceptedCVAsync([FromQuery] int postId, [FromQuery] int studentId, [FromQuery] bool isAccepted)
        {
            var result = await _postService.AcceptedCVAsync(postId, studentId, isAccepted);
            return Ok(result);
        }

        [Route("senimar-attend")]
        [HttpGet]
        [Authorize(Roles = "EmployeeHRM")]
        public async Task<IActionResult> GetSenimarAttendAsync([FromQuery] int postId, [FromQuery] int page)
        {
            var result = await _postService.GetSenimarStudentAsync(postId, page);
            return Ok(result);
        }
    }
}
