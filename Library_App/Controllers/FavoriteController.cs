using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("/favorites/{userId}")]
        public List<FavoriteResponse> GetFavoritesByUserId(int userId)
        {
            return _favoriteService.GetFavoritesByUserId(userId);
        }

        [Authorize]

        [HttpPost("/favorites")]
        public FavoriteResponse Create([FromForm] FavoriteRequest favoriteRequest)
        {
            return _favoriteService.Create(favoriteRequest);
        }
        [Authorize]

        [HttpDelete("/favorites/{id}")]
        public bool RemoveById(int id)
        {
            return _favoriteService.RemoveById(id);
        }

    }

}
