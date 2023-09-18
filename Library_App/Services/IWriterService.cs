using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IWriterService
    {
        public List<WriterResponse> GetAll();
        public WriterResponse GetById(int id);
        public WriterResponse Create(WriterRequest writerRequest);
        public WriterResponse Update(int id, WriterRequest writerRequest);
        public bool RemoveById(int id);

    }
}
