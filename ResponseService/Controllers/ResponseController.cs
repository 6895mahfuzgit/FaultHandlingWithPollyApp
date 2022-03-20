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
            try
            {
                var random = new Random();
                var ranInt = random.Next(1, 101);

                if (ranInt >= id)
                {
                    Console.WriteLine("Failed");
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                Console.WriteLine("OK");
                return Ok(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
