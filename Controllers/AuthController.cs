using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models.User;
using Span.Culturio.Api.Services.User;

namespace Span.Culturio.Api.Controllers {
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IValidator<RegisterUserDto> _validator;
        private readonly IUserService _userService;

        public AuthController(IValidator<RegisterUserDto> validator, IUserService userService) {
            _validator = validator;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUserDto) {
            ValidationResult result = _validator.Validate(registerUserDto);
            if (!result.IsValid) return BadRequest("ValidationError");

            var user = await _userService.RegisterUser(registerUserDto);
            if (user is null) return BadRequest();
            
            return Ok("Successful response");
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginUserDto) {
            var token = await _userService.Login(loginUserDto);
            if (token is null) return BadRequest("Bad username or password");

            return Ok(token);
        }

    }
}
