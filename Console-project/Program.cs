using Console_project.Exceptions;
using Console_project.Models;
using Console_project.Services;
using InvalidDataException = Console_project.Exceptions.InvalidDataException;


UserService userService = new UserService();
CategoryService categoryService = new CategoryService();
MedicineService medicineService = new MedicineService();

Console.WriteLine("Register user:");
Console.Write("Fullname: ");
string fullname = Console.ReadLine();
Console.Write("Email: ");
string email = Console.ReadLine();
Console.Write("Password: ");
string password = Console.ReadLine();

try
{
    userService.Register(fullname, email, password);
    Console.WriteLine("User was  registered.");
}
catch (InvalidDataException ex)
{
    Console.WriteLine(ex.Message);
    return;
}
User loggedInUser = null;
while (loggedInUser == null)
{
    Console.WriteLine("Login:");
    Console.Write("Email: ");
    email = Console.ReadLine();
    Console.Write("Password: ");
    password = Console.ReadLine();

    try
    {
        loggedInUser = userService.Login(email, password);
        Console.WriteLine($"User {loggedInUser.Fullname} - was logged in.");
    }
    catch (NotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }


    bool terminateApp = false;
    while (!terminateApp)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add Category.");
        Console.WriteLine("2. Get all Categories.");
        Console.WriteLine("3. Add Medicine.");
        Console.WriteLine("4. Get all Medicines.");
        Console.WriteLine("5. Find Medicine by ID.");
        Console.WriteLine("6. Find Medicine by Name.");
        Console.WriteLine("7. Find Medicine by Category ID.");
        Console.WriteLine("8. Remove Medicine.");
        Console.WriteLine("9. Update Medicine.");
        Console.WriteLine("0. Exit.");
        Console.Write("Select command: ");
        string command = Console.ReadLine();

        switch (command)
        {
            case "1":
                Console.Write("Enter category name: ");
                string categoryName = Console.ReadLine();
                categoryService.AddCategory(new Category(categoryName));
                Console.WriteLine("Category added.");
                break;

            case "2":
                Console.WriteLine("Categories:");
                categoryService.GetAllCategories();
                break;

            case "3":
                Console.Write("Enter medicine name: ");
                string medName = Console.ReadLine();
                Console.Write("Enter medicine price: ");
                decimal medPrice = decimal.Parse(Console.ReadLine());
                Console.Write("Enter category ID: ");
                int catId = int.Parse(Console.ReadLine());
                try
                {
                    medicineService.CreateMedicine(new Medicine(medName, medPrice, catId, loggedInUser.Id));
                    Console.WriteLine("Medicine added.");
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "4":
                Console.WriteLine("Medicines:");
                medicineService.GetAllMedicine();
                break;

            case "5":
                Console.Write("Enter medicine ID: ");
                int medId = int.Parse(Console.ReadLine());
                try
                {
                    Medicine foundMed = medicineService.GetMedicineById(medId);
                    Console.WriteLine($"ID: {foundMed.Id}, Name: {foundMed.Name}, Price: {foundMed.Price}, Category ID: {foundMed.CategoryId}, User ID: {foundMed.UserId}, Created Date: {foundMed.CreatedDate}");
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "6":
                Console.Write("Enter medicine name: ");
                string medSearchName = Console.ReadLine();
                try
                {
                    Medicine foundMedByName = medicineService.GetMedicineByName(medSearchName);
                    Console.WriteLine($"ID: {foundMedByName.Id}, Name: {foundMedByName.Name}, Price: {foundMedByName.Price}, Category ID: {foundMedByName.CategoryId}, User ID: {foundMedByName.UserId}, Created Date: {foundMedByName.CreatedDate}");
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "7":
                Console.Write("Enter category ID: ");
                int medCatId = int.Parse(Console.ReadLine());
                try
                {
                    Medicine foundMedByCatId = medicineService.GetMedicineByCategory(medCatId);
                    Console.WriteLine($"ID: {foundMedByCatId.Id}, Name: {foundMedByCatId.Name}, Price: {foundMedByCatId.Price}, Category ID: {foundMedByCatId.CategoryId}, User ID: {foundMedByCatId.UserId}, Created Date: {foundMedByCatId.CreatedDate}");
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "8":
                Console.Write("Enter medicine ID to remove: ");
                int removeMedId = int.Parse(Console.ReadLine());
                try
                {
                    medicineService.RemoveMedicine(removeMedId);
                    Console.WriteLine($"Medicine with ID:{removeMedId} removed.");
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "9":
                Console.Write("Enter medicine ID to update: ");
                int updateMedId = int.Parse(Console.ReadLine());
                Console.Write("Enter new medicine name: ");
                string updateMedName = Console.ReadLine();
                Console.Write("Enter new medicine price: ");
                decimal updateMedPrice = decimal.Parse(Console.ReadLine());
                Console.Write("Enter new category ID: ");
                int updateMedCatId = int.Parse(Console.ReadLine());
                Console.Write("Enter new user ID: ");
                int updateUserId = int.Parse(Console.ReadLine());
                try
                {
                    Medicine updatedMedicine = new Medicine(updateMedName, updateMedPrice, updateMedCatId, updateUserId);
                    medicineService.UpdateMedicine(updateMedId, updatedMedicine);
                    Console.WriteLine("Medicine updated.");
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "0":
                terminateApp = true;
                break;

            default:
                Console.WriteLine("Invalid command. Please try again.");
                break;
        }


    }

}