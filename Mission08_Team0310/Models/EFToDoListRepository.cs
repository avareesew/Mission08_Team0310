using System.Collections.Generic;
using System.Linq;

namespace Mission08_Team0310.Models
{
    public class EFToDoListRepository : IToDoListRepository
    {
        private readonly Mission08Context _context;

        public EFToDoListRepository(Mission08Context context)
        {
            _context = context;
        }

        public List<ToDoItem> ToDoItems => _context.ToDoItems.ToList();

        public List<Category> Categories => _context.Categories.ToList(); // Implement Categories property

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
