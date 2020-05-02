using Fisher.Bookstore.Models;
using Fisher.Bookstore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBooksRepository booksRepository;
        public BooksController(IBooksRepository repository){
            booksRepository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(booksRepository.GetBooks());
        }
        [HttpGet("{bookId}")]
        public IActionResult GetAction(int bookId)
        {
           if (!booksRepository.BookExists(bookId)){
               return NotFound();
           }
            return Ok(booksRepository.GetBook(bookId));
        }
   
    [HttpPost]
    public IActionResult Post([FromBody]Book book){
        var bookId = booksRepository.AddBook(book);
        return Created ($"hhtps://localhost:5001/api/books/{bookId}", book);
    }
    [HttpPut("{bookId}")]
    public IActionResult Put([FromRoute]int bookId, [FromBody]Book book){
        if (bookId != book.Id){
            return BadRequest();
        }
        if(!booksRepository.BookExists(bookId)){
            return NotFound();
        }
        booksRepository.UpdateBook(book);
        return Ok(book);
    }

    [HttpDelete("{bookId}")]
    [Authorize]
        public IActionResult Delete(int bookId)
        {
            if (!booksRepository.BookExists(bookId))
            {
                return NotFound();
            
            }

            booksRepository.DeleteBook(bookId);
            return Ok();
        }

    
    
    }
}