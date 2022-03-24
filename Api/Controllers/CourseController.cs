using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "View")]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public ActionResult<string> Index()
        {
            return "asdasd";
        }
    }
}
