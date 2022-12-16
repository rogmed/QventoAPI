using Microsoft.AspNetCore.Mvc;
using QventoAPI.Data;
using QventoAPI.Dto;
using QventoAPI.Facades;

namespace QventoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private InvitationFacade facade = new InvitationFacade(new Data.QventodbContext());

        [HttpPost]
        public IActionResult Post([FromBody] NewInvitationDto dto)
        {
            Invitation invitation = new()
            {
                QventoId = dto.QventoId,
                UserId = dto.UserId
            };

            MessageDto message = new MessageDto();

            if (facade.Exists(ref invitation, ref message))
                return Conflict(message);


            if (!facade.Save(ref invitation))
                return UnprocessableEntity(invitation);

            return Ok(invitation);
        }

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
