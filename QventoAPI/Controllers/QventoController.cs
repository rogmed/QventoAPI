using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QventoAPI.Data;

namespace QventoAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class QventoController : ControllerBase
    {
        IDbConnector dBconnector = new MockDbConnector();

        string okMessage = "200 OK \n\n" +
            "Para obtener Qventos usad la URL https://qvento.azurewebsites.net/qvento/{id}\n" +
            "Por ejemplo, poniendo https://qvento.azurewebsites.net/qvento/1 obtiene el Qvento\n con ID = 1.\n" +
            "Ahora mismo hay tres de prueba (0, 1 y 2), y poner otro número o letras da un error.";


        [HttpGet("")]
        public ActionResult<int> GetOk()
        {
            return Ok(okMessage);
        }


        [HttpGet("qvento/{qventoId}")]
        public ActionResult<Qvento> GetQvento(int qventoId)
        {
            QventodbContext context = new QventodbContext();
            var qvento = context.Qventos.FirstOrDefaultAsync(x => x.QventoId == qventoId);

            if (qvento == null)
                return NoContent();

            return Ok(qvento);
        }

        [HttpGet("qvento")]
        public ActionResult<List<Qvento>> GetQventos()
        {
            QventodbContext context = new QventodbContext();
            var allQventos = context.Qventos;

            if (allQventos == null)
                return NoContent();

            return Ok(allQventos);
        }

        [HttpGet("all-qventos")]
        public ActionResult<List<Qvento>> GetFakeQventos()
        {
            var allFakeQventos = dBconnector.FindAll();

            if (allFakeQventos == null)
                return NoContent();

            return Ok(allFakeQventos);
        }
    }
}