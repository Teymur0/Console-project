using Console_project.Models;

namespace Console_project.Services
{
    public class CategoryService
    {
        public void AddCategory(Category category)
        {
            Array.Resize(ref DB.categories, DB.categories.Length + 1);

            DB.categories[DB.categories.Length - 1] = category;
        }

    }
}
