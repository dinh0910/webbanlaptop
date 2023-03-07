using Microsoft.AspNetCore.Mvc;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorsController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
