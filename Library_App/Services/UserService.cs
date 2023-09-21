using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Pagination;
using Library_App.Repositories;

namespace Library_App.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public PaginationResponse<UserResponse> GetAll(int pageNo, int pageSize)
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var user in _userRepository.GetAll())
            {
                userResponses.Add(new UserResponse(user));
            }
            return new PaginationResponse<UserResponse>(userResponses, pageNo, pageSize);
        }

        public UserResponse GetById(int id)
        {
            User foundUser = _userRepository.GetById(id);
            if(foundUser!=null)
                return new UserResponse(foundUser);

            return null;
        }

        public UserResponse Update(int id, UserRequest userRequest)
        {
            User updatedUser = _userRepository.GetById(id);

            if(userRequest.Profil != null)
            {
                Models.File profile = null;
                if (userRequest.Profil.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        userRequest.Profil.CopyTo(stream);
                        var bytes = stream.ToArray();

                        profile = new Models.File()
                        {
                            Name = userRequest.Profil.FileName,
                            Type = userRequest.Profil.ContentType,
                            Content = bytes
                        };
                    }
                }
                updatedUser.Profil = profile;
            }

            updatedUser.FirstName = userRequest.FirstName;
            updatedUser.LastName = userRequest.LastName;

            string[] date = userRequest.BornDate.Split('-');
            updatedUser.BornDate = new DateTime((int)Int64.Parse(date[0]), (int)Int64.Parse(date[1]), (int)Int64.Parse(date[2]));

            updatedUser.Gender = userRequest.Gender;
            updatedUser.About = userRequest.About;

            User returnedUser = _userRepository.Update(updatedUser);
            return new UserResponse(returnedUser);
        }

    }

}
