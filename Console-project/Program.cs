using Console_project.Models;
using Console_project.Services;


UserService userService = new UserService();
CategoryService categoryService = new CategoryService();
MedicineService medicineService = new MedicineService();

Console.Write("Enter your email:");
var email = Console.ReadLine();
Console.Write("Enter your password:");
var password = Console.ReadLine();