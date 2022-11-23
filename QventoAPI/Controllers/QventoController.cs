using Microsoft.AspNetCore.Mvc;
using QventoAPI.Data;
using QventoAPI.Dto;

namespace QventoAPI.Controllers
{
    /// <summary>
    ///   Public API controller for Qventos
    /// </summary>
    [ApiController]
    [EndpointGroupName("Qventos")]
    [Route("/")]
    public class QventoController : ControllerBase
    {
        IDbConnector dBconnector = new MockDbConnector();
        QventodbContext context = new QventodbContext();
        QventoMapper mapper = new QventoMapper();
        QventoFacade facade = new QventoFacade();

        /// <summary>
        /// Ok message
        /// </summary>
        [HttpGet("")]
        public ActionResult<int> GetOk()
        {
            string okMessage = "200 OK \n\n" +
            "Github: https://github.com/rogmed/QventoAPI\n" +
            "Swagger: https://qvento.azurewebsites.net/swagger/index.html\n";
            return Ok(okMessage);
        }

        /// <summary>
        /// Retrieves Qvento based on its ID.
        /// </summary>
        /// <param name="qventoId">Qvento Id</param>
        [HttpGet("qvento/{qventoId}")]
        public ActionResult<Qvento> GetQvento(int qventoId)
        {
            var qvento = context.Qventos.SingleOrDefault(x => x.QventoId == qventoId);

            if (qvento == null)
                NoContent();

            return Ok(qvento);
        }

        /// <summary>
        /// Retrieves all the Qventos
        /// </summary>
        [HttpGet("qvento")]
        public ActionResult<List<Qvento>> GetQventos()
        {
            var allQventos = context.Qventos;

            if (allQventos == null)
                NoContent();

            return Ok(allQventos);
        }

        /// <summary>
        /// ONLY FOR TESTING. Retrieves some fake Qventos not from database.
        /// </summary>
        [HttpGet("all-qventos")]
        public ActionResult<List<Qvento>> GetFakeQventos()
        {
            var allQventos = dBconnector.FindAll();

            if (allQventos == null)
                return NoContent();

            return Ok(allQventos);
        }

        /// <summary>
        /// POST new Qvento
        /// </summary>
        /// <param name="dto">qventoDto</param>
        [HttpPost("qvento")]
        public ActionResult<QventoDto> PostQvento([FromBody] QventoDto dto)
        {
            var qvento = mapper.MaptoQvento(dto);

            if (!facade.Save(ref qvento))
                return UnprocessableEntity();

            var outgoingDto = mapper.MapToDto(qvento);

            return Ok(outgoingDto);
        }

        /// <summary>
        /// Delete a Qvento based on its ID
        /// </summary>
        /// <param name="qventoId">Qvento Id</param>
        [HttpDelete("qvento")]
        public ActionResult<bool> Delete(int qventoId)
        {
            if (!facade.Delete(qventoId))
                return NoContent();

            return Ok();
        }
    }
}