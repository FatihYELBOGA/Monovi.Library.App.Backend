﻿using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface IBookService
    {
        public List<BookResponse> GetAll();
        public PaginationResponse<BookResponse> GetAllByPagination(int pageNo, int pageSize);
        public BookResponse GetById(int id);
        public PaginationResponse<BookResponse> GetAllByUserId(int userId, int pageNo, int pageSize);
        public PaginationResponse<BookResponse> GetAllByWriterId(int writerId, int pageNo, int pageSize);
        public BookResponse Create(BookRequest bookRequest);
        public BookResponse Update(int id, BookRequest bookRequest);
        public bool RemoveById(int id);

    }

}
