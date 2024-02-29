
namespace Mission08_Team0310.Models
{
    public class EFToDoListRepository : IToDoListRepository
    {
        private Mission08Context _context;
        public EFToDoListRepository(Mission08Context temp)
        {
            _context = temp;
        }
        public List<ToDoItem> ToDoItems => _context.ToDoItems.ToList();
    }
}
