using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Services;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsRepository authorsRepository;

        public AuthorsController(IAuthorsRepository repository){
            authorsRepository = repository;
        }

        [HttpGet]
        public IActionResult GetAuthors(){
            return Ok(authorsRepository.GetAuthors());
        }

        [HttpGet ("{bookId}")]
        public IActionResult Get(int AuthorId){
            if(!authorsRepository.AuthorExists(AuthorId)){
               return NotFound(); 
            }
            return Ok(authorsRepository.GetAuthor(AuthorId));
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Author author){
            var AuthorId = authorsRepository.AddAuthor(author);
            return Created ($"https://localhost:5001/api/authors/ {AuthorId}", author);
        }

        [HttpPut("{AuthorId}")]

        public IActionResult Put(int AuthorId, [FromBody] Author author){
            if(AuthorId != author.Id){
                return BadRequest();
            }
            if(!authorsRepository.AuthorExists(AuthorId)){
                return NotFound();
            }

            authorsRepository.UpdateAuthor(author);
            return Ok(author);
        }
        [HttpDelete("{authorId}")]
        public IActionResult Delete(int authorId){
            if(!authorsRepository.AuthorExists(authorId))
            {
                return NotFound();

            }

            authorsRepository.DeleteAuthor(authorId);
                return Ok();
        }


    }
}