using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperChatsWebAPI.Models;

namespace SuperChatsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UserController : ControllerBase   //les autres c'est controller, lui c'est controllerbase??
    {
        UserManager<User> UserManager;

        public UserController(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        [HttpPost]   //c'est enregistrer un nouveau user, donc post, pas get
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if(registerDTO.Password!=registerDTO.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest, 
                    new {Message="Les deux mots de passe spécifiés sont différents."}); //Ce message est hardcodé, on peut faire i18n pour francais anglais etc.
            }

            User user = new User()
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Email
            };

            IdentityResult identityResult= await this.UserManager.CreateAsync(user, registerDTO.Password);  //le deuxième dans CreateAsync va faire le hachage!!

            if(!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "La création de l'utilisateur a échoué." });
            }

            return Ok();  //code 200 pour dire c'est réussi
        }
    }
}
