using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookSharingController : ControllerBase
    {

        private readonly IBookSharingService _bookSharingService;

        public BookSharingController(IBookSharingService bookSharingService)
        {
            _bookSharingService = bookSharingService;
        }

        [HttpGet("/book-sharing/{userId}")]
        public List<BookSharingResponse> GetAllBookSharings(int userId)
        {
            return _bookSharingService.GetAllBookSharings(userId);
        }

        [HttpGet("/book-sharing")]
        public bool CheckBookSharing([FromQuery] int user1, [FromQuery] int user2, [FromQuery] int bookId)
        {
            return _bookSharingService.CheckBookSharing(user1, user2, bookId);
        }

        [HttpPost("/book-sharing")]
        public BookSharingResponse Create([FromForm] BookSharingRequest bookSharingRequest)
        {
            return _bookSharingService.Create(bookSharingRequest);
        }

    }
}
