using Microsoft.AspNetCore.Mvc;

namespace QventoAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class QventoController : ControllerBase
    {
        IDbConnector dBconnector = new MockDbConnector();

        string okMessage = "200 OK \n" +
            "Para obtener Qventos usad la URL https://qvento.azurewebsites.net/qvento/{id}\n" +
            "Por ejemplo, poniendo https://qvento.azurewebsites.net/qvento/1 obtiene el Qvento\n" +
            "con ID = 1. Ahora mismo hay tres de prueba (0, 1 y 2), y poner otro número o letras da un error.";


        [HttpGet("")]
        public ActionResult<int> GetOk()
        {
            return Ok(okMessage);
        }


        [HttpGet("qvento/{qventoId}")]
        public ActionResult<Qvento> GetQvento(string qventoId)
        {
            Qvento qvento = dBconnector.FindQvento(qventoId);

            if (qvento == null)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(qvento);
        }

        [HttpGet("all-qventos")]
        public ActionResult<List<Qvento>> GetFakeQventos()
        {
            var allQventos = dBconnector.FindAll();

            if (allQventos == null)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(allQventos);
        }
    }
}