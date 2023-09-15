using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IUserService
    {
        public UserResponse GetById(int id);
        public UserResponse Update(int id, UserRequest userRequest);
    }

}
