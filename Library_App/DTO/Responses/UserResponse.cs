using Library_App.Enumerations;
using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public FileResponse Profil { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BornDate { get; set; }
        public Gender Gender { get; set; }
        public string? About { get; set; }

        public UserResponse(User user) 
        {
            Id = user.Id;
            Email = user.Email;
            Role = user.Role;
            FirstName = user.FirstName;
            LastName = user.LastName;
            BornDate = user.BornDate;
            Gender = user.Gender;
            About = user.About;

            if (user.Profil != null)
                Profil = new FileResponse(user.Profil);

        }   

    }

}
