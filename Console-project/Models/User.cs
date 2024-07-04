namespace Console_project.Models
{
    public class User : BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public User(string fullName, string email, string passwrord)
        {
            Fullname = fullName;
            Email = email;
            Password = passwrord;
        }

    }


}
