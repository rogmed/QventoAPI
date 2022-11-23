using Microsoft.AspNetCore.Mvc;
using QventoAPI.Data;

namespace QventoAPI.Controllers
{
    /// <summary>
    ///   Some test endpoints
    /// </summary>
    [ApiController]
    [EndpointGroupName("Tests")]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        MockContext dBconnector = new MockContext();

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
    }
}

