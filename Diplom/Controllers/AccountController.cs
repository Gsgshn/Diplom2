using Azure.Messaging;
using Diplom.Contracts;
using Diplom.Data;
using Diplom.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Diplom.DTO.ServiceResponses;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<User> userManager,
        RoleManager<IdentityRole<Guid>> roleManager, IUser user, ApplicationDbContext context) : ControllerBase
    {

        

        

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var response = await user.CreateAccount(userDTO);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var response = await user.LoginAccount(loginDTO);
            return Ok(response);
        }


        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateAccount(UserUpdateDTO userUpdateDTO)
        {
            if (userUpdateDTO == null) return Content("GG email is empty");
            var user1 = await userManager.FindByEmailAsync(userUpdateDTO.EmailAddress);

           

            if (userUpdateDTO.Name != null) user1.Name = userUpdateDTO.Name;
            if (userUpdateDTO.Password != null) await userManager.ChangePasswordAsync(user1, userUpdateDTO.Password, userUpdateDTO.Password);
            //if (app != null) user1.AppId = app.Id;


            await userManager.UpdateAsync(user1);

            return Ok(user);


        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteAccount(UserUpdateDTO userUpdateDTO)
        {
            if (userUpdateDTO == null) return Content("GG email is empty");
            var user = await userManager.FindByEmailAsync(userUpdateDTO.EmailAddress);



            await userManager.DeleteAsync(user);
            return Ok();
        }

        [HttpGet("GetAllAccount")]
        public async Task<List<User>> GetAllAccount()
        {
            return await user.GetAllAccount();
        }

        [HttpGet("GetAccount")]
        public async Task<User> GetUser(Guid Id)
        {
            return await user.GetUser(Id);
        }

        [HttpPost("AddAppToUser")]
        public async Task<GeneralResponse> AddAppToUser(UserUpdateDTO userUpdateDTO)
        {
            var app = await context.Apps.Where(c => c.Name == userUpdateDTO.App).FirstOrDefaultAsync();
            await user.AddAppToUser(userUpdateDTO, app.Id);
            return new GeneralResponse(true, "App append");
        }
    }
}
