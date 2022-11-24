using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QventoAPI.Data;
using QventoAPI.Dto;
using QventoAPI.Facades;
using QventoAPI.Mappers;

namespace QventoAPI.Controllers
{
    /// <summary>
    ///   Public API for Qvento Users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserFacade facade = new UserFacade();
        UserMapper mapper = new UserMapper();

        /// <summary>
        ///    Retrieves USer based on its ID.
        /// </summary>
        /// <param name="userId">User Id</param>
        [HttpGet("{userId}")]
        public ActionResult<User> Get(int userId)
        {
            var user = facade.Get(userId);

            if (user == null)
                NoContent();

            return Ok(user);
        }

        /// <summary>
        ///    Register new User
        /// </summary>
        /// <param name="dto">User Dto</param>
        [HttpPost]
        public ActionResult<UserDto> Post(NewUserDto dto)
        {
            var newUser = mapper.MapToNewUser(dto);

            if (!facade.Save(ref newUser))
                UnprocessableEntity();

            var savedUserDto = mapper.MapToDto(newUser);

            return Ok(savedUserDto);
        }
    }
}
