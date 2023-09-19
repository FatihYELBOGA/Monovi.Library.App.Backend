using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class BookSharingResponse
    {
        public int Id { get; set; }
        public UserResponse SenderUser { get; set; }
        public UserResponse ReceiverUser { get; set; }
        public BookResponse Book { get; set; }

        public BookSharingResponse(SharingBooks sharingBook)
        {
            Id = sharingBook.Id;

            if (sharingBook.SenderUser != null)
                SenderUser = new UserResponse(sharingBook.SenderUser);

            if (sharingBook.ReceiverUser != null)
                ReceiverUser = new UserResponse(sharingBook.ReceiverUser);

            if(sharingBook.Book != null)
                Book = new BookResponse(sharingBook.Book);

        }

    }

}
