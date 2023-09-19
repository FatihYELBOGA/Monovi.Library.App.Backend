using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WriterController : ControllerBase
    {

        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("/writers")]
        public List<WriterResponse> GetAll()
        {
            return _writerService.GetAll();
        }

        [HttpGet("/writers/{id}")]
        public WriterResponse GetById(int id)
        {
            return _writerService.GetById(id);
        }

        [HttpPost("/writers")]
        public WriterResponse Create([FromForm] WriterRequest writerRequest)
        {
            return _writerService.Create(writerRequest);
        }

        [HttpPut("/writers/{id}")]
        public WriterResponse Update(int id, [FromForm] WriterRequest writerRequest)
        {
            return _writerService.Update(id, writerRequest);
        }

        [HttpDelete("/writers/{id}")]
        public bool RemoveById(int id)
        {
            return _writerService.RemoveById(id);
        }

    }
}
