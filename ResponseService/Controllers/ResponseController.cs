using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetResponse(int id)
        {
            return Ok(id);  
        }

    }
}
