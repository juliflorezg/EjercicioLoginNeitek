using EjercicioLoginNeitekBackend.DTOs;
using EjercicioLoginNeitekBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioLoginNeitekBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        [FromKeyedServices("UserService")] IUserService userService, JwtService jwtService) : ControllerBase
    {

        private readonly IUserService _userService = userService;
        private readonly JwtService _jwtService = jwtService;

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

            if (user == null) return BadRequest("Credenciales invalidas");

            bool isPassWordCorrect = _userService.ValidatePassword(loginDTO);

            if (isPassWordCorrect)
            {
                var userTypeName = await _userService.GetUserTypeNameById(user);
                var token = _jwtService.GenerateToken(user.Id, user.Email, userTypeName);

                return Ok(new { token });
            }

            return Unauthorized("Credenciales invalidas");
        }
    }
}
