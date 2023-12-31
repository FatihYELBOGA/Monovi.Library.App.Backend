﻿using Library_App.Enumerations;
using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class BookResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public BookType BookType { get; set; }
        public int PageNumber { get; set; }
        public Language Language { get; set; }
        public float Point { get; set; } 
        public FileResponse? Photo { get; set; }
        public FileResponse? Content { get; set; }
        public UserResponse? User { get; set; }
        public WriterResponse? Writer { get; set; }  

        public BookResponse() { }   

        public BookResponse(Book book) 
        { 
            Id = book.Id;
            Name = book.Name;
            Description = book.Description;
            BookType = book.BookType;
            PageNumber = book.PageNumber;
            Language = book.Language;

            Point = (float) 0.0;
            int totalRating = 0;
            int totalCounter = 0;
            if(book.BookRatings != null)
            {
                if(book.BookRatings.Count() != 0)
                {
                    foreach (var rating in book.BookRatings)
                    {
                        totalRating += rating.Point;
                        totalCounter++;
                    }
                    Point = (float) totalRating / totalCounter;
                }
            }

            if(book.Photo != null)
                Photo = new FileResponse(book.Photo);

            if (book.Content != null)
                Content = new FileResponse(book.Content);

            if (book.User != null)
                User = new UserResponse(book.User);

            if (book.Writer != null)
            {
                WriterResponse writerResponse = new WriterResponse();
                writerResponse.Id = book.Writer.Id;
                writerResponse.FirstName = book.Writer.FirstName;
                writerResponse.LastName = book.Writer.LastName;
                writerResponse.Gender = book.Writer.Gender;
                writerResponse.Nationality = book.Writer.Nationality;
                writerResponse.Biography = book.Writer.Biography;
                writerResponse.Books = new List<BookResponse>();

                if (book.Writer.Profil != null)
                    writerResponse.Profil = new FileResponse(book.Writer.Profil);

                Writer = writerResponse;
            }

        }

    }

}
