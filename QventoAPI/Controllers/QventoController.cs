using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using QventoAPI.Data;
using QventoAPI.Dto;
using QventoAPI.Facades;
using QventoAPI.MAppers;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace QventoAPI.Controllers
{
    /// <summary>
    ///   Public API controller for Qventos
    /// </summary>
    [Route("api/qventos")]
    [ApiController]
    [EndpointGroupName("Qventos")]
    public class QventoController : ControllerBase
    {
        QventoMapper mapper = new QventoMapper();
        QventoFacade facade = new QventoFacade();

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
        /// <param name="dto">qventoDto</param>
        [HttpPost("")]
        public ActionResult<QventoDto> Post([FromBody] QventoDto dto)
        {
            var qvento = mapper.MaptoQvento(dto);

            if (!facade.Save(ref qvento))
                return UnprocessableEntity();

            var outgoingDto = mapper.MapToOutgoingDto(qvento);

            return Ok(outgoingDto);
        }

        /// <summary>
        /// Delete a Qvento based on its ID
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
        /// <param name="dto">Qvento Dto</param>
        [HttpPut("")]
        public ActionResult<Qvento> Update([FromBody] QventoDto dto)
        {
            Qvento qvento = mapper.MaptoQvento(dto);

            if (!facade.Update(ref qvento))
                return NoContent();

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
        ///    Get Qventos related to an User
        /// </summary>
        /// <param name="userId">UserId</param>
        [HttpGet("relevant/{userId}")]
        public ActionResult<List<Qvento>> GetRelevantUser(int userId)
        {
            var qventos = facade.GetRelevantToUser(userId);

            return Ok(qventos);
        }
    }
}