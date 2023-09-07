using Library_App.Enumerations;

namespace Library_App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ProfilId { get; set; }
        public File? Profil { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public Gender Gender { get; set; }
        public string? About { get; set; }
        public List<Book> Books { get; set; }
        public List<BookComments> BookComments { get; set; }
        public List<FavoriteBooks> FavoriteBooks { get; set; }
        public List<BookRatings> BookRatings { get; set; }
        public List<UserFriends> UserFriendsOne { get; set; }
        public List<UserFriends> UserFriendsTwo { get; set; }
        public List<SharingBooks> SenderBooks { get; set; }
        public List<SharingBooks> ReceiverBooks { get; set; }

    }

}