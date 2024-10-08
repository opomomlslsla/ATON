using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService service) : ControllerBase
    {
        private readonly UserService _userService = service;


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            var token = await _userService.Login(user.Email, user.Password);
            HttpContext.Response.Cookies.Append("tasty-token",token);
            return Ok(token);
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> Register(RegisterDTO user)
        {
            //User.Claims.First(x => x.Type == ClaimTypes.Name).Value
            var s = await _userService.Register(user);
            return s ? Ok("registration completed") : BadRequest("ti pidor");
        }

        [HttpGet("GetDataForAdmin")]
        [Authorize(Roles = "admin")]
        public IActionResult GetData()
        {
            return Ok("some data");
        }

        [HttpGet("GetDataForUser")]
        [Authorize(Roles = "user,admin")]
        public IActionResult GetOtherData()
        {
            return Ok("some other data");
        }

    }
}
