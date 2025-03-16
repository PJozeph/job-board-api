using System.Text.Json.Serialization;

namespace JobBoard.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        public User()
        {
            if (FirstName == null)
            {
                FirstName = "";
            }
            if (LastName == null)
            {
                LastName = "";
            }
            if (Email == null)
            {
                Email = "";
            }

            if (PasswordHash == null)
            {
                PasswordHash = new byte[0];
            }
            if (PasswordSalt == null)
            {
                PasswordSalt = new byte[0];
            }
            if (Gender == null)
            {
                Gender = "";
            }
        }
    }
}