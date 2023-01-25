using Microsoft.AspNetCore.Mvc;
using QventoAPI.Data;
using QventoAPI.Dto;
using QventoAPI.Facades;

namespace QventoAPI.Controllers
{
    /// <summary>
    ///    Public API controller for Invitations to Qventos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private InvitationFacade facade = new InvitationFacade(new Data.QventodbContext());

        /// <summary>
        ///    Post a new Invitation given a dto with QventoId and Email of an existing user
        /// </summary>
        /// <param name="dto">New Invitation Dto</param>
        /// <returns>Ok(invitation)</returns>
        [HttpPost]
        public IActionResult Post([FromBody] NewInvitationDto dto)
        {
            int userId = facade.FindUserId(dto.Email);

            if (userId == 0)
            {
                return NoContent();
            }

            Invitation invitation = new()
            {
                QventoId = dto.QventoId,
                UserId = userId
            };

            MessageDto message = new MessageDto();

            if (facade.Exists(ref invitation, ref message))
                return Conflict(message);


            if (!facade.Save(ref invitation))
                return UnprocessableEntity(invitation);

            return Ok("Usuario invitado.");
        }

        /// <summary>
        ///    Updates the status of an Invitation given a dto with a new status
        /// </summary>
        /// <param name="dto">Invitation Dto</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] InvitationDto dto)
        {
            var foundInvitation = facade.Get(dto);
            if (foundInvitation == null)
                return UnprocessableEntity(dto);

            MessageDto message = new();
            if (!facade.Update(ref foundInvitation, dto, ref message))
                return UnprocessableEntity(message);

            return Ok(foundInvitation);
        }
    }
}
