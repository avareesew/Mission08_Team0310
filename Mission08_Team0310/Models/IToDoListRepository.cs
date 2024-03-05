namespace Mission08_Team0310.Models
{
    public interface IToDoListRepository
    {
        List<ToDoItem> ToDoItems { get; }

        List<Category> Categories { get; }

        public void AvasSpecialAdd(ToDoItem item);

        public void AvasSpecialDelete(ToDoItem item);

        public void AvasSpecialUpdate(ToDoItem item);

    }
}
