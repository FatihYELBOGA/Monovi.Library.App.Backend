using Library_App.Enumerations;

namespace Library_App.DTO.Requests
{
    public class WriterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile? Profil { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string Biography { get; set; }

    }
}
