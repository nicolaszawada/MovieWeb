using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.Client.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult World([FromQuery] string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
