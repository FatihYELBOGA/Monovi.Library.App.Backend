using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public UserResponse User { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }

        public CommentResponse(BookComments comment) 
        {
            Id  = comment.Id;

            if(comment.User!=null)
                User = new UserResponse(comment.User);
                
            Comment = comment.Comment;
            CommentDate = comment.CommentDate;
        }

    }

}
