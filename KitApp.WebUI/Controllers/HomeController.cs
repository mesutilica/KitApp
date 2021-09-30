using KitApp.Core.Entities;
using KitApp.Core.Services;
using KitApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KitApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            //var books = await _bookService.GetAllAsync();books
            return View();
        }
        public async Task<AppUser> AddAsync(AppUser appUser)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(appUser), Encoding.UTF8, "application/json");//SerializeObject nesneyi json a dönüştür
            var response = await _httpClient.PostAsync("AppUsers", stringContent);
            if (response.IsSuccessStatusCode)
            {
                appUser = JsonConvert.DeserializeObject<AppUser>(await response.Content.ReadAsStringAsync());
                return appUser;
            }
            else
            {
                //todo:hatayı loglama yap
                return null;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
