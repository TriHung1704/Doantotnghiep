using CooperateApplication.Service.Model;
using CooperateApplication.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CooperateApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : Controller
    {
        private readonly IMajorsService _majorsService;

        public MajorsController(IMajorsService majorsService)
        {
            _majorsService = majorsService;
        }

        [HttpGet]
        public async Task<IActionResult> MajorsAsync()
        {
            var majors = await _majorsService.GetAll();
            return Ok(majors.ToListModel());
        }
    }
}
