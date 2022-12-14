using Microsoft.AspNetCore.Mvc;
using QventoAPI.Data;
using QventoAPI.Dto;
using QventoAPI.Facades;
using QventoAPI.MAppers;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace QventoAPI.Controllers
{
    /// <summary>
    ///    Public API controller for Qventos
    /// </summary>
    [Route("api/qventos")]
    [ApiController]
    [EndpointGroupName("Qventos")]
    public class QventoController : ControllerBase
    {
        QventoMapper mapper = new QventoMapper();
        QventoFacade facade = new QventoFacade(new QventodbContext());
        UserFacade userFacade = new UserFacade(new QventodbContext());

        /// <summary>
        ///    Retrieves Qvento based on its ID.
        /// </summary>
        /// <param name="qventoId">Qvento Id</param>
        [HttpGet("{qventoId}")]
        public ActionResult<Qvento> Get(int qventoId)
        {
            var qvento = facade.Get(qventoId);

            if (qvento == null)
                NoContent();

            return Ok(qvento);
        }

        /// <summary>
        ///    Retrieves all the Qventos
        /// </summary>
        [HttpGet("")]
        public ActionResult<List<Qvento>> GetAll()
        {
            var allQventos = facade.GetAll();

            if (allQventos == null)
                NoContent();

            return Ok(allQventos);
        }

        /// <summary>
        ///    POST new Qvento
        /// </summary>
        /// <param name="tempToken">User Temporary Token</param>
        /// <param name="dto">Qvento Dto</param>
        [HttpPost("{tempToken}")]
        public ActionResult<QventoDto> Post(string tempToken, [FromBody] NewQventoDto dto)
        {
            int userId = userFacade.Authenticate(tempToken);
            if (userId == -1)
                return Unauthorized();

            QventoDto authorizedDto = new QventoDto(userId, dto);

            var qvento = mapper.MaptoQvento(authorizedDto);

            if (!facade.Save(ref qvento))
                return UnprocessableEntity();

            var outgoingDto = mapper.MapToOutgoingDto(qvento);

            return Ok(outgoingDto);
        }

        /// <summary>
        ///    Delete a Qvento based on its ID
        /// </summary>
        /// <param name="qventoId">Qvento Id</param>
        [HttpDelete("{qventoId}")]
        public ActionResult<bool> Delete(int qventoId)
        {
            if (!facade.Delete(qventoId))
                return NoContent();

            return Ok();
        }

        /// <summary>
        ///    Update an existing Qvento
        /// </summary>
        /// <param name="qventoId">Qvento Id</param>
        /// <param name="dto">Qvento Dto</param>
        [HttpPut("{qventoId}")]
        public ActionResult<Qvento> Update(int qventoId, [FromBody] NewQventoDto dto)
        {
            Qvento? qvento = null;

            if (!facade.Update(ref qvento, qventoId, dto))
                return UnprocessableEntity();

            return Ok(qvento);
        }

        /// <summary>
        ///    Get Qventos related to an User
        /// </summary>
        /// <param name="userId">UserId</param>
        [HttpGet("createdby/{userId}")]
        public ActionResult<List<Qvento>> GetCreatedByUser(int userId)
        {
            var qventos = facade.GetCreatedByUser(userId);

            return Ok(qventos);
        }

        /// <summary>
        ///    Get Qventos related to an User provided a Temporary Token
        /// </summary>
        /// <param name="tempToken">TempToken</param>
        [HttpGet("relevant/{tempToken}")]
        public ActionResult<List<Qvento>> GetRelevantUser(string tempToken)
        {
            var qventos = facade.GetRelevantToUser(tempToken);

            return Ok(qventos);
        }
    }
}
