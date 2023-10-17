using Library_App.Models;
using Library_App.Repositories;

namespace Library_App.GraphQL.Writer
{
    public class WriterQuery
    {

        private readonly IWriterRepository _writerRepository;

        public WriterQuery(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public List<Models.Writer> writers => _writerRepository.GetAll();
        public Models.Writer writerById(int id) => _writerRepository.GetById(id);

    }

}
