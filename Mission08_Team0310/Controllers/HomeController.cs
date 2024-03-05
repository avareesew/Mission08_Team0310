using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0310.Models;
using System.Diagnostics;

namespace Mission08_Team0310.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoListRepository _repo;
        // private readonly Mission08Context _context;

        public HomeController(IToDoListRepository temp
            // , //Mission08Context context) 
            )
        {
            _repo = temp;
           // _context = context;
        }

        public IActionResult Index()
        {
            var firstToDoItem = _repo.ToDoItems.FirstOrDefault(x => x.Quadrant == 1);
            return View(firstToDoItem);
        }


        [HttpPost]
        public IActionResult AddTasks(ToDoItem response)
        {
            _repo.AvasSpecialAdd(response);
            return RedirectToAction("Index"); // Redirect to another action, such as Index
        }

        [HttpGet]
        public IActionResult AddTasks()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View();
        }

        public IActionResult Quadrants()
        {
            var ToDoItems = _repo.ToDoItems
                .Where(x => x.Completed == false)
                .ToList();

            return View(ToDoItems);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var recordToEdit = _repo.ToDoItems
                .Single(x => x.TaskId == Id);

            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddTasks", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(ToDoItem updatedInfo)
        {
            _repo.AvasSpecialUpdate(updatedInfo);
            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var recordToDelete = _repo.ToDoItems
                .Single(x => x.TaskId == Id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(ToDoItem task)
        {
            _repo.AvasSpecialDelete(task);

            return RedirectToAction("Quadrants");
        }
    }
}
