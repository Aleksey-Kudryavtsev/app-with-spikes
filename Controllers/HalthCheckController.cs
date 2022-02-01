using Microsoft.AspNetCore.Mvc;

namespace AppWithLoadSpikes.Controllers
{
    [Route(".well-known")]
    [ApiController]
    public class HealthChecksController : ControllerBase
    {
        [HttpGet]
        [Route("live")]
        public ActionResult Liveness() => Ok();

        [HttpGet]
        [Route("ready")]
        public ActionResult Readiness() => Ok();
    }
}
