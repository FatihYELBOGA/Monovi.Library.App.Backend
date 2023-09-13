using Library_App.Enumerations;
using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class WriterResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string Biography { get; set; }

        public WriterResponse(Writer writer) 
        {
            Id = writer.Id;
            FirstName = writer.FirstName;
            LastName = writer.LastName;
            Gender = writer.Gender;
            Nationality = writer.Nationality;
            Biography = writer.Biography;
        }

    }

}
