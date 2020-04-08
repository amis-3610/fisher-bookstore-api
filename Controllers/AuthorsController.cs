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

        [HttpGet("{authorID}")]
        public IActionResult Get(int authorID)
        {
             if (!authorsRepository.AuthorExists(authorID))
            {
                return NotFound();
            }
            return Ok(authorsRepository.GetAuthor(authorID));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            var authorId = authorsRepository.AddAuthor(author);
            return Created($"https://localhost:5001/api/authors/{authorId}", author);
        }

        [HttpPut("{authorId}")]
        public IActionResult Put(int authorId, [FromBody] Author author)
        {
            if (authorId != author.Id)
            {
                return BadRequest();
            }

            if (!authorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            authorsRepository.UpdateAuthor(author);
            return Ok(author);
        }

        [HttpDelete("{authorId}")]
        public IActionResult Delete(int authorId)
        {
            if (!authorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            authorsRepository.DeleteAuthor(authorId);
            return Ok();
        }
    }
}