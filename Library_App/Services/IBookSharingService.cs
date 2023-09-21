using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface IBookSharingService
    {
        public PaginationResponse<BookSharingResponse> GetAllBookSharings(int userId, int pageNo, int pageSize);
        public bool CheckBookSharing(int user1, int user2, int bookId);
        public BookSharingResponse Create(BookSharingRequest bookSharingRequest);

    }
}
