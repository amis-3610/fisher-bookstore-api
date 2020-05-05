using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase 
    {
        private IAuthorsRepository authorsRepository;

        public AuthorsController(IAuthorsRepository repository)
        {
            authorsRepository = repository;
        }
        
        
        [HttpGet]
        public IActionResult GetAll()
        {

        return Ok();
        }
    }
}
