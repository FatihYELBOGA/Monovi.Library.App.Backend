﻿namespace Library_App.Models
{
    public class BookComments
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }

    }

}