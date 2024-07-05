

using Console_project.Exceptions;

namespace Console_project.Models
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        private int _categoryId;
        public int CategoryId
        {
            get => CategoryId;
            set
            {
                if (CategoryChecker(value))
                {

                   _categoryId= value;
                }
                else
                {
                    throw new NotFoundException("Id not found");
                }
            }

        }
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Medicine(string name, decimal price, int categoryId, int userId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
            UserId = userId;
            CreatedDate = DateTime.Now;
        }

        public bool CategoryChecker(int id)
        {
            foreach (var itemId in DB.categories)
            {
                if (itemId.Id == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
