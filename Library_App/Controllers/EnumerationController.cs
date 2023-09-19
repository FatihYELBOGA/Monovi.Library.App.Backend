using Library_App.Enumerations;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnumerationController : ControllerBase
    {

        [HttpGet("/enumerations/books")]
        public BookType[] GetAllBookTypes()
        {
            return (BookType[]) Enum.GetValues(typeof(BookType));
        }

        [HttpGet("/enumerations/genders")]
        public Gender[] GetAllGenders()
        {
            return (Gender[]) Enum.GetValues(typeof(Gender));
        }

        [HttpGet("/enumerations/languages")]
        public Language[] GetAllLanguages()
        {
            return (Language[])Enum.GetValues(typeof(Language));
        }

        [HttpGet("/enumerations/nationalities")]
        public Nationality[] GetAllNationalities()
        {
            return (Nationality[])Enum.GetValues(typeof(Nationality));
        }

        [HttpGet("/enumerations/request-status")]
        public RequestStatus[] GetAllRequestStatus()
        {
            return (RequestStatus[])Enum.GetValues(typeof(RequestStatus));
        }

        [HttpGet("/enumerations/roles")]
        public Role[] GetAllRoles()
        {
            return (Role[]) Enum.GetValues(typeof(Role));
        }

    }
}
