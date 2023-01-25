using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QventoAPI.Dto;
using QventoAPI.Facades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QventoAPI.Controllers
{
    /// <summary>
    ///    Public API for Qvento web login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserFacade facade = new UserFacade(new Data.QventodbContext());

        /// <summary>
        ///    Try to login provided credentials with e-mail and password
        /// </summary>
        /// <param name="dto">Credentials Dto</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] CredentialsDto dto)
        {
            int userId = 0;

            if (facade.CheckIfEmailIsAvailable(dto.Email))
                return UnprocessableEntity("E-mail not registered.");

            if (!facade.Login(ref userId, dto))
                return Unauthorized();

            var tempToken = facade.GenerateToken(dto);
            if (tempToken == null)
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            var claims = new[]
            {
                new Claim("userId", userId.ToString()),
                new Claim("email", dto.Email),
                new Claim("tempToken", tempToken)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_12345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://www.qvento.es",
                audience: dto.Email,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { Token = tokenString });
        }
    }
}
