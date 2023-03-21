using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuperChatsWebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuperChatsWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserManager<User> UserManager;
        IConfiguration Config;

        public UsersController(UserManager<User> userManager, IConfiguration configuration)
        {
            this.UserManager = userManager;
            Config = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if(registerDTO.Password != registerDTO.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les deux mots de passe spécifiés sont différents."});
            }

            User user = new User()
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
                NickName=registerDTO.NickName
            };

            IdentityResult identityResult = await UserManager.CreateAsync(user, registerDTO.Password);
            if(!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La création de l'utilisateur a échoué." });
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            User user = await UserManager.FindByNameAsync(loginDTO.Username);
            if(user != null && await UserManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                IList<string> roles = await UserManager.GetRolesAsync(user);
                List<Claim> authClaims = new List<Claim>();
                foreach(string role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                //SymmetricSecurityKey key = SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuioplkjhgfdsazxcvbnmqwertlkjfdslkjflksjfklsjfklsjdflskjflyuioplkjhgfdsazxcvbnmmnbv"));
                SymmetricSecurityKey key = SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Config["JWT:Secret"]));


                JwtSecurityToken token = new JwtSecurityToken(
                     issuer: "http://localhost:4200",
                     audience: "https://localhost:7096",
                     claims: authClaims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    validTo = token.ValidTo
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Le nom de l'utilisateur ou le mot de passe est invalide"
                    });
            }
        }

        private SymmetricSecurityKey SymmetricSecurityKey(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
