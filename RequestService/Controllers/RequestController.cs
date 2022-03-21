using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            return Ok();
        }
    }
}
