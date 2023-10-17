using Library_App.DTO.Requests;
using Library_App.Repositories;

namespace Library_App.GraphQL.Writer
{
    public class WriterMutation
    {

        private readonly IWriterRepository _writerRepository;

        public WriterMutation(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public Models.Writer Create(WriterTypeRequest writer)
        {
            Models.Writer addedWriter = new Models.Writer()
            {
                FirstName = writer.FirstName,
                LastName = writer.LastName,
                Gender = writer.Gender,
                Nationality = writer.Nationality,
                Biography = writer.Biography
            };

            return _writerRepository.Create(addedWriter);
        }

    }

}
