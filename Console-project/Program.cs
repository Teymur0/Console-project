using Console_project.Models;
using Console_project.Services;
using System.Reflection.Emit;

User newUser = new User("exampleUser", "examle@example.com", "qwerty123");
bool isLoggedUser = false;
UserService userService = new UserService();
userService.AddUser(newUser);

Console.Write("Enter your email:");
string email = Console.ReadLine();

Console.Write("Enter your password:");
string password = Console.ReadLine();

isLoggedUser = userService.Login(email, password);
