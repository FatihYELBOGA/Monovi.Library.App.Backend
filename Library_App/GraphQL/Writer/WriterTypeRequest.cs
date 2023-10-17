using Library_App.Enumerations;

namespace Library_App.GraphQL.Writer
{
    public class WriterTypeRequest 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string Biography { get; set; }

    }

}
