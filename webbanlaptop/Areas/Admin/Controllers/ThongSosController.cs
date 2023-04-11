using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using webbanlaptop.Data;

namespace webbanlaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongSosController : Controller
    {
        private readonly webbanlaptopContext _context;
        private readonly IToastNotification _toastNotification;

        public ThongSosController(webbanlaptopContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
    }
}
