namespace JobBoard.Dtos
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterDTO()
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
            if(Gender == null)
            {
                Gender = "";
            }
            if (Password == null)
            {
                Password = "";
            }
            if (ConfirmPassword == null)
            {
                ConfirmPassword = "";
            }
        }

    }
}