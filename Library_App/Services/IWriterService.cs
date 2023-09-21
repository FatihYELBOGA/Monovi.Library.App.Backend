using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface IWriterService
    {
        public PaginationResponse<WriterResponse> GetAll(int pageNo, int pageSize);
        public List<WriterResponse> GetAllNames();
        public WriterResponse GetById(int id);
        public WriterResponse Create(WriterRequest writerRequest);
        public WriterResponse Update(int id, WriterRequest writerRequest);
        public bool RemoveById(int id);

    }
}
