using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface IUserService
    {
        public List<UserResponse> GetAll();
        public PaginationResponse<UserResponse> GetAllByPagination(int pageNo, int pageSize);
        public UserResponse GetById(int id);
        public UserResponse Update(int id, UserRequest userRequest);
        public bool RemoveById(int id);

    }

}
