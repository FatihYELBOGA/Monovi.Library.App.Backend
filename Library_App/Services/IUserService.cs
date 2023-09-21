using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface IUserService
    {
        public PaginationResponse<UserResponse> GetAll(int pageNo, int pageSize);
        public UserResponse GetById(int id);
        public UserResponse Update(int id, UserRequest userRequest);

    }

}
