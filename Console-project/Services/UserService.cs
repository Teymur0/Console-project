using Console_project.Models;

namespace Console_project.Services
{
    internal class UserService
    {
        public bool Login(string email, string password)
        {
            for (int i = 0; i < DB.users.Length; i++)
            {
                if (email == DB.users[i].Email && password == DB.users[i].Password)
                {
                    return true;
                }


            }

            return false;
        }


        public void AddUser(User user)
        {
            Array.Resize(ref DB.users, DB.users.Length + 1);

            DB.users[DB.users.Length - 1] = user;
        }

    }
}
