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
        UserMapper mapper = new UserMapper();
        UserFacade facade = new UserFacade(new QventodbContext());

        /// <summary>
        ///    Retrieves User based on its ID.
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
        /// <param name="dto">New User Dto</param>
        [HttpPost]
        public ActionResult<NewUserDto> Post(NewUserDto dto)
        {
            var newUser = mapper.MapToNewUser(dto);

            if (!facade.CheckIfEmailIsAvailable(dto.Email))
                return Conflict(newUser);

            if (!facade.Save(ref newUser))
                return UnprocessableEntity(newUser);

            var savedUserDto = mapper.MapToDto(newUser);

            return Ok(savedUserDto);
        }
    }
}
