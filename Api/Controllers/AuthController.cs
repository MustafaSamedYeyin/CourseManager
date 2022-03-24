using Core.Interfaces.Bussiness;
using Core.Interfaces.Bussiness.Jwt;
using DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _authService.ChechUserExixstAsync(loginDto);
                if (user)
                {
                    var jsonWebToken = await _authService.LoginAsync(loginDto, _configuration["Configuration:key"], _configuration["Configuration:Issuer"], _configuration["Configuration:Audience"]);
                    return Ok(jsonWebToken);
                }
                else if (user == null)
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(registerDto);
                if (result == true)
                {
                    return Created(new Uri("https://localhost:7136/api/Course/GetCoursesByUserId"), registerDto);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
            

        }
    }
}
