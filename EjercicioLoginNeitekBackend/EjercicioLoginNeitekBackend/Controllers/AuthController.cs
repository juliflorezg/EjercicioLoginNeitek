using EjercicioLoginNeitekBackend.DTOs;
using EjercicioLoginNeitekBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioLoginNeitekBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        [FromKeyedServices("UserService")] IUserService userService) : ControllerBase
    {

        private readonly IUserService _userService = userService;

        [HttpPost("signup")]
        public async Task<ActionResult<UserDTO>> SignUp([FromBody] UserCreateDTO userCreateDTO)
        {
            if (!_userService.Validate(userCreateDTO))
            {
                return BadRequest(_userService.Errors);
            }

            var userDTO = await _userService.Add(userCreateDTO);

            return Ok(userDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = _userService.GetByEmail(loginDTO);

            if (user == null) return BadRequest("Invalid credentials");

            bool isPassWordCorrect = _userService.ValidatePassword(loginDTO);

            if ((isPassWordCorrect))
            {
                return Ok();
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
