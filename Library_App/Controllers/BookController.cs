using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("/books")]
        public List<BookResponse> GetAll()
        {
            return new List<BookResponse>();
        }

        [HttpGet("/books/{id}")]
        public BookResponse GetById(int id)
        {
            return new BookResponse();
        }

        [HttpPost("/books")]
        public BookResponse Create([FromForm] BookRequest bookRequest)
        {
            return new BookResponse();
        }

        [HttpPut("/books/{id}")]
        public BookResponse Update(int id, [FromForm] BookRequest bookRequest)
        {
            return new BookResponse();
        }

        [HttpDelete("/books/{id}")]
        public bool RemoveById(int id)
        {
            return true;
        }


    }

}
