using Library_App.Enumerations;

namespace Library_App.DTO.Requests
{
    public class UserRequest
    {
        public IFormFile? Profil { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BornDate { get; set; }
        public Gender Gender { get; set; }
        public string? About { get; set; }

    }

}
