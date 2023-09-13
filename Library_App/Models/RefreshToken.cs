namespace Library_App.Models
{
    public class RefreshToken
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }

}
