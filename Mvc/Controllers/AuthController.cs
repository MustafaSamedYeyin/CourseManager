using DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Mvc.Services;

namespace Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            await _authService.RegisterAsync(registerDto);
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            if (!string.IsNullOrEmpty(token))
            {
                Response.Cookies.Append("CourseManagerJwt", token);
                return RedirectToAction("Index","Home");
            }
            ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("CourseManagerJwt");
            return RedirectToAction("Index", "Home");
        }
    }
}
