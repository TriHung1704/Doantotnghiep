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

        public EnterpriseController(IEnterpriseEmployeeService enterpriseEmployeeService, IPostService postService)
        {
            _enterpriseEmployeeService = enterpriseEmployeeService;
            _postService = postService;
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
