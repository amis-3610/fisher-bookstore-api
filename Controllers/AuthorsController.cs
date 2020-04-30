using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsRepository AuthorsRepository;

        public AuthorsController(IAuthorsRepository repository)
        {
            AuthorsRepository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(AuthorsRepository.GetAuthors());
        }

        [HttpGet("{authorId}")]
        public IActionResult Get(int authorId)
        {
            if (!AuthorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            return Ok(AuthorsRepository.GetAuthor(authorId));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            var authorId  = AuthorsRepository.AddAuthor(author);
            return Created($"https://localhost:5001/api/authors/{authorId}", author);
        }

        [HttpPut("{authorId}")]
        public IActionResult Put(int authorId, [FromBody] Author author)
        {
            if (authorId != author.Id)
            {
                return BadRequest();
            }

            if (!AuthorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            AuthorsRepository.UpdateAuthor(author);
            return Ok(author);
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int authorId)
        {
            if (!AuthorsRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            AuthorsRepository.DeleteAuthor(authorId);
            return Ok();
        }
    }
}