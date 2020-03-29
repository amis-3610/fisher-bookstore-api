using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controler]")]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}