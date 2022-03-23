using Core.Interfaces.Bussiness;
using Core.Interfaces.Bussiness.Jwt;
using DTOs.Auth;
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
                var user = await _authService.ChechUserExixstAsync(loginDto.Email);
                if (user)
                {
                     return Ok(await _authService.LoginAsync(loginDto,_configuration["Configuration:key"],_configuration["Configuration:Issuer"],_configuration["Configuration:Audience"]));
                }
                else if (user == null)
                {
                    return StatusCode(500);
                }
            }
            return BadRequest();
        }
    }
}
