namespace Console_project.Models
{
    public abstract class BaseEntity
    {
        public int Id { get;}

        public BaseEntity()
        {
            Id++;
        }
    }
}
