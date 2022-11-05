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
                Description = "Esta es la descripci�n del Qvento de prueba. " +
                "El veloz murci�lago hind� com�a feliz cardillo y kiwi. La cig�e�a " +
                "tocaba el saxof�n detr�s del palenque de paja."
            },

            new Qvento()
            {
                QventoId = "1",
                Title = "Segundo Qvento de prueba",
                Description = "Le gustaba cenar un exquisito s�ndwich de jam�n con " +
                "zumo de pi�a y vodka fr�a. El viejo Se�or G�mez ped�a queso, kiwi " +
                "y habas, pero le ha tocado un saxof�n. Exh�banse politiquillos " +
                "zafios, con orejas kilom�tricas y u�as de gavil�n.  "
            },

            new Qvento()
            {
                QventoId = "2",
                Title = "Tercer Qvento de prueba",
                Description = "Le gustaba cenar un exquisito s�ndwich de jam�n con " +
                "zumo de pi�a y vodka fr�a. El viejo Se�or G�mez ped�a queso, kiwi " +
                "y habas, pero le ha tocado un saxof�n. Exh�banse politiquillos " +
                "zafios, con orejas kilom�tricas y u�as de gavil�n.  "
            }
        };

        string okMessage = "200 OK \n" +
            "Para obtener Qventos usad la URL https://qvento.azurewebsites.net/qvento/{id}\n" +
            "Por ejemplo, poniendo https://qvento.azurewebsites.net/qvento/1 obtiene el Qvento\n" +
            "con ID = 1. Ahora mismo hay tres de prueba (0, 1 y 2), y poner otro n�mero o letras da un error.";


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