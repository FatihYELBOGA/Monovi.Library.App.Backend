using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;
using System.Security.Cryptography.Xml;

namespace Library_App.Services
{
    public class BookSharingService : IBookSharingService
    {

        private readonly IBookSharingRepository _bookSharingRepository;

        public BookSharingService(IBookSharingRepository bookSharingRepository)
        {
            _bookSharingRepository = bookSharingRepository;
        }

        public List<BookSharingResponse> GetAllBookSharings(int userId)
        {
            List<BookSharingResponse> bookSharingResponses = new List<BookSharingResponse>();   
            foreach (var sharing in _bookSharingRepository.GetAllBookSharings(userId))
            {
                bookSharingResponses.Add(new BookSharingResponse(sharing));
            }
            return bookSharingResponses;
        }

        public bool CheckBookSharing(int user1, int user2, int bookId)
        {
            SharingBooks foundSharing = _bookSharingRepository.CheckBookSharing(user1, user2, bookId);
            if (foundSharing != null)
                return true;

            return false;
        }

        public BookSharingResponse Create(BookSharingRequest bookSharingRequest)
        {
            SharingBooks addedSharing = new SharingBooks()
            {
                SenderUserId = bookSharingRequest.SenderUserId,
                ReceiverUserId = bookSharingRequest.ReceiverUserId,
                BookId = bookSharingRequest.BookId
            };
            SharingBooks returnedSharing = _bookSharingRepository.Create(addedSharing);

            return new BookSharingResponse(returnedSharing);
        }

    }
}
