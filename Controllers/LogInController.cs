using HCA.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace HCA.Controllers
{
    public class LogInController : Controller
    {
        private readonly HCAContext _context;

        public LogInController(HCAContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
