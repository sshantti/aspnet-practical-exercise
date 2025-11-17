using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Добавим отладочный вывод
            var isAuthenticated = HttpContext.Session.GetString("IsAuthenticated") == "true";
            var userEmail = HttpContext.Session.GetString("UserEmail");

            Console.WriteLine($"DEBUG: IsAuthenticated = {isAuthenticated}");
            Console.WriteLine($"DEBUG: UserEmail = {userEmail}");
            Console.WriteLine($"DEBUG: Session ID = {HttpContext.Session.Id}");

            ViewData["IsAuthenticated"] = isAuthenticated;
            ViewData["UserEmail"] = userEmail;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
