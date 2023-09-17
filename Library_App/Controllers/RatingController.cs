using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {

        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [Authorize]
        [HttpGet("/ratings")]
        public RatingResponse GetByBookAndUserId([FromQuery] int bookId, [FromQuery] int userId)
        {
            return _ratingService.GetByBookAndUserId(bookId, userId);
        }

        [Authorize]
        [HttpPost("/ratings")]
        public RatingResponse Create([FromForm] RatingRequest ratingRequest)
        {
            return _ratingService.Create(ratingRequest);
        }

        [Authorize]
        [HttpPut("/ratings")]
        public RatingResponse Update([FromForm] RatingRequest ratingRequest)
        {
            return _ratingService.Update(ratingRequest);
        }

    }

}
