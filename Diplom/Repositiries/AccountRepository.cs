using Diplom.Contracts;
using Diplom.Data;
using Diplom.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Diplom.DTO.ServiceResponses;

namespace Diplom.Repositiries
{
    public class AccountRepository(UserManager<User> userManager, 
        RoleManager<IdentityRole> roleManager, 
        IConfiguration config) : IUser
    {
        public async Task<GeneralResponse> CreateAccount(UserDTO userDTO)
        {
            if (userDTO is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.EmailAddress,
                PasswordHash = userDTO.Password,
                UserName = userDTO.EmailAddress
            }; 
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new ServiceResponses.GeneralResponse(false, "User registered alredy");

            var createUser = await  userManager.CreateAsync(newUser!,userDTO.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error create user");


            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if(checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Afmin Account Created");

            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null)
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
                }
                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true, "Account Created");
                
            }
        }

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return new LoginResponse(false, null!, "Login container is empty");

            var getUser = await userManager.FindByEmailAsync(loginDTO.EmailAddress);
            if (getUser is null)
                return new LoginResponse(false, null!, "User not found");

            bool checkUserPassword = await userManager.CheckPasswordAsync(getUser, loginDTO.Password);
            if (!checkUserPassword)
                return new LoginResponse(false, null!, "Invalid email/password");

            var getUserRole = await userManager.GetRolesAsync(getUser);
            var userSessions = new UserSession(getUser.Id, getUser.Name, getUser.Email, getUserRole.First());
            string token = GenerateToken(userSessions);
            return new LoginResponse(true, token, "Login completed");
        }

        private string GenerateToken(UserSession userSession)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userSession.Id),
                new Claim(ClaimTypes.Name, userSession.Name),
                new Claim(ClaimTypes.Email, userSession.Email),
                new Claim(ClaimTypes.Role, userSession.Role)
            };
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
