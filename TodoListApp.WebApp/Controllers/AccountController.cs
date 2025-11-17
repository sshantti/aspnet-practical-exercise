using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TodoListApp.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            // Добавим отладочный вывод
            Console.WriteLine("DEBUG: Setting session for demo user");

            HttpContext.Session.SetString("IsAuthenticated", "true");
            HttpContext.Session.SetString("UserId", "demo-user");
            HttpContext.Session.SetString("UserEmail", "demo@example.com");

            // Проверим что записалось
            var test = HttpContext.Session.GetString("IsAuthenticated");
            Console.WriteLine($"DEBUG: Session set successfully? {test}");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessLogin(string email, string password)
        {
            // Добавляем простую проверку пароля (для демо)
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("UserId", email);
                HttpContext.Session.SetString("UserEmail", email);

                return RedirectToAction("Index", "Home");
            }

            // Если email или password пустые, возвращаем обратно
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult ProcessRegister(string email, string password, string confirmPassword)
        {
            // Простая регистрация с проверкой пароля
            if (!string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(password) &&
                password == confirmPassword)
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("UserId", email);
                HttpContext.Session.SetString("UserEmail", email);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Register");
        }

        public IActionResult DemoLogin()
        {
            HttpContext.Session.SetString("IsAuthenticated", "true");
            HttpContext.Session.SetString("UserId", "demo-user");
            HttpContext.Session.SetString("UserEmail", "demo@example.com");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DemoRegister()
        {
            HttpContext.Session.SetString("IsAuthenticated", "true");
            HttpContext.Session.SetString("UserId", "demo-user");
            HttpContext.Session.SetString("UserEmail", "demo@example.com");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAuthenticated");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserEmail");

            return RedirectToAction("Index", "Home");
        }
    }
}
