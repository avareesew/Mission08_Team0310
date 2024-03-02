using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0310.Models;
using System.Diagnostics;

namespace Mission08_Team0310.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoListRepository _repo;
        private readonly Mission08Context _context;

        public HomeController(IToDoListRepository temp, Mission08Context context)
        {
            _repo = temp;
            _context = context;
        }

        public IActionResult Index()
        {
            var firstToDoItem = _repo.ToDoItems.FirstOrDefault(x => x.Quadrant == 1);
            return View(firstToDoItem);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTasks(ToDoItem response)
        {
            _context.ToDoItems.Add(response);
            _context.SaveChanges();
            return RedirectToAction("Index"); // Redirect to another action, such as Index
        }

        [HttpGet]
        public IActionResult AddTasks()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        public IActionResult Quadrants()
        {
            var ToDoItems = _context.ToDoItems
                .Where(x => x.Completed == false)
                .ToList();

            return View(ToDoItems);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var recordToEdit = _context.ToDoItems
                .Single(x => x.TaskId == Id);

            ViewBag.Categories = _context.Categories.ToList();
            return View("AddTasks", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(ToDoItem updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var recordToDelete = _context.ToDoItems
                .Single(x => x.TaskId == Id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(ToDoItem task)
        {
            _context.ToDoItems.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
