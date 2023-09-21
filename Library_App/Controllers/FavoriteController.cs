using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoriteController : ControllerBase
    {

        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("/favorites/{userId}")]
        public PaginationResponse<FavoriteResponse> GetFavoritesByUserId(int userId, [FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _favoriteService.GetFavoritesByUserId(userId, pageNo, pageSize);
        }

        [HttpGet("/favorites")]
        public FavoriteResponse CheckFavorite([FromQuery] int bookId, [FromQuery] int userId)
        {
            return _favoriteService.CheckFavorite(bookId, userId);
        }

        [HttpPost("/favorites")]
        public FavoriteResponse Create([FromForm] FavoriteRequest favoriteRequest)
        {
            return _favoriteService.Create(favoriteRequest);
        }

        [HttpDelete("/favorites/{id}")]
        public bool RemoveById(int id)
        {
            return _favoriteService.RemoveById(id);
        }

    }

}
