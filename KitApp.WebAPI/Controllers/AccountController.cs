using KitApp.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KitApp.WebAPI.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLogin appUserLogin)
        {
            if (ModelState.IsValid)
            {
                
                ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı");
            }
            return View(appUserLogin);
        }
    }
}
