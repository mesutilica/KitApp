using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KitApp.Core.Entities;
using KitApp.WebAPI.Data;
using KitApp.Core.Services;

namespace KitApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService _context;

        public AppUsersController(IAppUserService context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetAppUsers()
        {
            var list = await _context.GetAllAsync();
            return list;
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(int id)
        {
            var appUser = await _context.GetByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        [HttpPut("{id}")]
        public IActionResult PutAppUser(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Update(appUser);
            }
            catch
            {
                return Problem("Hata Oluştu!");
            }
            return NoContent();
        }

        // POST: api/AppUsers
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            await _context.AddAsync(appUser);

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var appUser = await _context.GetByIdAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.Remove(appUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
