using Microsoft.AspNetCore.Mvc;
using Mission08_Team0310.Models;
using System.Diagnostics;

namespace Mission08_Team0310.Controllers
{
    public class HomeController : Controller
    {
        private IToDoListRepository _repo;

        public HomeController(IToDoListRepository temp)
        {
            _repo = temp;
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

    }
}
