using Microsoft.AspNetCore.Mvc;

namespace QventoAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class QventoController : ControllerBase
    {
        List<Qvento> qventos = new List<Qvento>()
        {
            new Qvento() 
            {
                QventoId = "0",
                Title = "Qvento de prueba",
                Description = "Esta es la descripción del Qvento de prueba. " +
                "El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña " +
                "tocaba el saxofón detrás del palenque de paja."
            },

            new Qvento()
            {
                QventoId = "1",
                Title = "Segundo Qvento de prueba",
                Description = "Le gustaba cenar un exquisito sándwich de jamón con " +
                "zumo de piña y vodka fría. El viejo Señor Gómez pedía queso, kiwi " +
                "y habas, pero le ha tocado un saxofón. Exhíbanse politiquillos " +
                "zafios, con orejas kilométricas y uñas de gavilán.  "
            },

            new Qvento()
            {
                QventoId = "2",
                Title = "Tercer Qvento de prueba",
                Description = "Le gustaba cenar un exquisito sándwich de jamón con " +
                "zumo de piña y vodka fría. El viejo Señor Gómez pedía queso, kiwi " +
                "y habas, pero le ha tocado un saxofón. Exhíbanse politiquillos " +
                "zafios, con orejas kilométricas y uñas de gavilán.  "
            }
        };

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
            int parsedQventoId;
            Qvento? qvento = null;

            if (int.TryParse(qventoId, out parsedQventoId))
            {
                qvento = qventos.Find(x => x.QventoId.Equals(qventoId));
            }

            if (qvento == null)
                return StatusCode(StatusCodes.Status204NoContent);

            return Ok(qvento);
        }
    }
}