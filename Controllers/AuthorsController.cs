using Fisher.Bookstore.Services;
using Fisher.Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase{
        private IAuthorsRepository authorsRespository;
        public AuthorsController(IAuthorsRepository repository){
            authorsRespository = repository;
        }
        [HttpGet]
        public IActionResult GetAll(){
            return Ok(authorsRespository.GetAuthors());
        }
        [HttpGet("{authorId}")]
        public IActionResult Get(int authorId){
            if(!authorsRespository.AuthorExists(authorId)){
                return NotFound();
            }
            return Ok(authorsRespository.GetAuthor(authorId));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Author author ){
            var authorId = authorsRespository.AddAuthor(author);
            return Created($"https://localhost:5001/api/authors/{authorId}", author);
        }
        [HttpPut("{authorId}")]
        public IActionResult Put(int authorId, [FromBody] Author author){
            if(authorId != author.Id){
                return BadRequest();
            }
            if(!authorsRespository.AuthorExists(authorId)){
                return NotFound();
            }
            authorsRespository.UpdateAuthor(author);
            return Ok(author);
        }
        [HttpDelete("{authorId}")]
        public IActionResult Delete(int authorId){
            if(!authorsRespository.AuthorExists(authorId)){
                return NotFound();
            }
            authorsRespository.DeleteAuthor(authorId);
            return Ok();
        }
    }
}