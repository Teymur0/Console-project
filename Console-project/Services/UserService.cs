using Console_project.Exceptions;
using Console_project.Models;
using System.Text.RegularExpressions;
using InvalidDataException = Console_project.Exceptions.InvalidDataException;

namespace Console_project.Services
{
    internal class UserService
    {

        public bool ValidateFullName(string name)
        {
            if (name == null || name.Length < 3)
            {

                return false;
            }

            foreach (char c in name)
            {
                if (char.IsUpper(c))
                {
                    return true;
                }

            }

            return false;
        }
        public bool ValidateEmailAddress(string email)
        {
            if (email == null)
            {
                return false;
            }
            string emailPattern = @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
            return Regex.IsMatch(email, emailPattern);

        }

        public bool ValidatePassword(string password)
        {
            bool isUpper = false;
            bool isLower = false;
            bool isDigit = false;

            if (password == null || password.Length < 8)
            {
                return false;
            }

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {

                    isUpper = true;
                }
                if (char.IsLower(c))
                {

                    isLower = true;
                }
                if (char.IsDigit(c))
                {

                    isDigit = true;
                }
                if (isUpper && isLower && isDigit)
                {
                    return true;
                }

            }

            return false;

        }
        public void Register(string fullname, string email, string password)
        {

            if (fullname == null) { }

            if (ValidateFullName(fullname) && ValidateEmailAddress(email) && ValidatePassword(password))
            {
                User newUser = new User(fullname, email, password);

                AddUser(newUser);
            }

            else
            {
                throw new InvalidDataException("Data is not valid.");
            }

        }


        public User Login(string email, string password)
        {
            foreach (var user in DB.users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            throw new NotFoundException("User not found.");
        }


        public void AddUser(User user)
        {
            Array.Resize(ref DB.users, DB.users.Length + 1);

            DB.users[DB.users.Length - 1] = user;
        }

    }
}
