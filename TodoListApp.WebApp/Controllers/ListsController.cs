using Microsoft.AspNetCore.Mvc;
using TodoListApp.WebApp.Models;
using TodoListApp.WebApp.Services;

namespace TodoListApp.WebApp.Controllers
{
    public class ListsController : Controller
    {
        private readonly ITaskService _taskService;

        public ListsController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            // Получаем UserId из сессии или используем демо
            var userId = HttpContext.Session.GetString("UserId") ?? "demo-user";
            var lists = await _taskService.GetUserListsAsync(userId);
            return View(lists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskList list)
        {
            if (ModelState.IsValid)
            {
                list.UserId = HttpContext.Session.GetString("UserId") ?? "demo-user";
                await _taskService.CreateListAsync(list);
                return RedirectToAction(nameof(Index));
            }
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = HttpContext.Session.GetString("UserId") ?? "demo-user";
            await _taskService.DeleteListAsync(id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
