using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Services;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBooksRepository booksRespository;
        public BooksController(IBooksRepository repository){
            booksRespository = repository;
        }
        [HttpGet]
        public IActionResult GetAll(){
            return Ok(booksRespository.GetBooks());
        }

        [HttpGet("{bookId}")]
        public IActionResult Get(int bookId){
            if(!booksRespository.BookExists(bookId)){
                return NotFound();
            }
            return Ok(booksRespository.GetBook(bookId));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book ){
            var bookId = booksRespository.AddBook(book);
            return Created($"https://localhost:5001/api/books/{bookId}", book);
        }

        [HttpPut("{bookId}")]
        public IActionResult Put(int bookId, [FromBody] Book book){
            if(bookId != book.Id){
                return BadRequest();
            }

            if(!booksRespository.BookExists(bookId)){
                return NotFound();
            }
            booksRespository.UpdateBook(book);
            return Ok(book);
        }

        [HttpDelete("{bookId}")]
        public IActionResult Delete(int bookId){

            if(!booksRespository.BookExists(bookId)){
                return NotFound();
            }

            booksRespository.DeleteBook(bookId);
            return Ok();

        }

    }
}