using Microsoft.AspNetCore.Mvc;

namespace QventoAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class EventController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEvent")]
        public IEnumerable<Event> Get()
        {
            return Enumerable.Range(1,1).Select(index => new Event
            {
                Title = "Evento de prueba",
                Description = "Descripción del evento de prueba"

            })
            .ToArray();
        }
    }
}