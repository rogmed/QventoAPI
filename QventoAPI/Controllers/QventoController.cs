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
        QventodbContext context = new QventodbContext();

        


        [HttpGet("")]
        public ActionResult<int> GetOk()
        {
            string okMessage = "200 OK \n\n" +
            "Github: https://github.com/rogmed/QventoAPI\n" +
            "Swagger: https://qvento.azurewebsites.net/swagger/index.html\n";
            return Ok(okMessage);
        }


        [HttpGet("qvento/{qventoId}")]
        public ActionResult<Qvento> GetQvento(int qventoId)
        {
            var qvento = context.Qventos.SingleOrDefault(x => x.QventoId == qventoId);

            if (qvento == null)
                NoContent();

            return Ok(qvento);
        }

        [HttpGet("qvento")]
        public ActionResult<List<Qvento>> GetQventos()
        {
            var allQventos = context.Qventos;

            if (allQventos == null)
                NoContent();

            return Ok(allQventos);
        }

        [HttpGet("all-qventos")]
        public ActionResult<List<Qvento>> GetFakeQventos()
        {
            var allQventos = dBconnector.FindAll();

            if (allQventos == null)
                return NoContent();

            return Ok(allQventos);
        }
    }
}