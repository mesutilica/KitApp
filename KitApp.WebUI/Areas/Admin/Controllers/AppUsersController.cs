using AutoMapper.Configuration;
using KitApp.Core.Entities;
using KitApp.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUsersController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IConfiguration _configuration;

        public AppUsersController(IAppUserService appUserService, IConfiguration configuration)
        {
            _appUserService = appUserService;
            _configuration = configuration;
        }

        // GET: AppUsersController
        public async Task<IActionResult> IndexAsync()
        {
            var list = await _appUserService.GetAllAsync();
            return View(list);
        }

        // GET: AppUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AppUser appUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _appUserService.AddAsync(appUser);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(appUser);
            }
        }

        // GET: AppUsersController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _appUserService.GetByIdAsync(id.Value);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: AppUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appUserService.Update(appUser);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }
                
            }
            return View(appUser);
        }

        // GET: AppUsersController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _appUserService.SingleOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: AppUsersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appUser = await _appUserService.GetByIdAsync(id);
            _appUserService.Remove(appUser);
            return RedirectToAction(nameof(Index));
        }
    }
}
