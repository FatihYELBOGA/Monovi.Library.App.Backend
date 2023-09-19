using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IBookSharingService
    {
        public List<BookSharingResponse> GetAllBookSharings(int userId);
        public bool CheckBookSharing(int user1, int user2, int bookId);
        public BookSharingResponse Create(BookSharingRequest bookSharingRequest);

    }
}
