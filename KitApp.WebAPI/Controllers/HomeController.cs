using KitApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KitApp.WebAPI.Controllers
{
    [EnableCors]
    public class HomeController : Controller
    {
        private readonly IBookService _context;
        public HomeController(IBookService context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Authorize]
        public IActionResult Books()
        {
            //var books = await _context.GetAllAsync();
            return View();//books
        }
        [Authorize]
        public IActionResult MyBooks()
        {
            return View();
        }

    }
}
