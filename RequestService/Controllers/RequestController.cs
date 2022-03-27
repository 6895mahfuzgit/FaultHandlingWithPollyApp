using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        //private readonly ClientPolicy _policy;
        private readonly IHttpClientFactory _httpClientFactory;

        public RequestController(IHttpClientFactory httpClientFactory) //ClientPolicy policy,
        {
            //_policy = policy;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            try
            {

                //var client = new HttpClient();
                //var response = await client.GetAsync("https://localhost:7027/api/Response/100");

                var client = _httpClientFactory.CreateClient("Test");
                var response = await client.GetAsync("https://localhost:7027/api/Response/100");

                //var response = await _policy.ImmidiateHttpPolicy.ExecuteAsync(
                //                            () =>
                //                            client.GetAsync("https://localhost:7027/api/Response/25")
                //                            );

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("<-----  Response returned SUCCESS. ----->");
                    return Ok();
                }

                Console.WriteLine("<-----  Response returned FAILED.   ----->");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
