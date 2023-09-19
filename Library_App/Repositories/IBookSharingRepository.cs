using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IBookSharingRepository
    {
        public List<SharingBooks> GetAllBookSharings(int userId);
        public SharingBooks CheckBookSharing(int user1, int user2, int bookId);
        public SharingBooks Create(SharingBooks sharingBook);

    }
}
