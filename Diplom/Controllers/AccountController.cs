using Diplom.Contracts;
using Diplom.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController( IUser user) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var response = await user.CreateAccount(userDTO);
            return Ok(response);
        }

        [HttpPost ("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var response = await user.LoginAccount(loginDTO);
            return Ok(response);
        }
    }
}
