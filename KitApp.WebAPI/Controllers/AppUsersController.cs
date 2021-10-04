using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KitApp.Core.Entities;
using KitApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using KitApp.WebAPI.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace KitApp.WebAPI.Controllers
{
    [EnableCors]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService _context;
        private readonly IBookService _bookService;
        private readonly IUserBooksService _userBookService;
        public AppUsersController(IAppUserService context, IBookService bookService, IUserBooksService userBookService)
        {
            _context = context;
            _bookService = bookService;
            _userBookService = userBookService;
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
            try
            {
                var user = _context.FirstOrDefaultAsync(u => u.Email == appUser.Email);
                if (user != null)
                {
                    return Conflict(new { message = $" '{appUser.Email}' mail adresi sistemde zaten kayıtlı." });
                }
                appUser.CreateDate = DateTime.Now;
                appUser.IsActive = true;
                await _context.AddAsync(appUser);
                return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
            }
            catch (Exception)
            {
                return Problem("Hata Oluştu!");
            }
        }

        [HttpPost("PostBookAdd")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        public async Task<ActionResult<PostBookAdd>> PostBookAddAsync(PostBookAdd postBookAdd)//[FromBody] IActionResult
        {
            try
            {
                var appUser = await _context.SingleOrDefaultAsync(x => x.RefreshToken == postBookAdd.RefreshToken);

                if (appUser == null)
                {
                    return NotFound();
                }
                var book = await _bookService.GetByIdAsync(postBookAdd.Id);

                if (book == null)
                {
                    return NotFound();
                }
                var userbooks = await _userBookService.Where(x => x.AppUserId == appUser.Id);
                if (userbooks.ToList().Count >= 3)
                {
                    return Problem("Max 3 kitap alınabilir!", statusCode: StatusCodes.Status417ExpectationFailed);
                }
                var userbook = userbooks.FirstOrDefault(x => x.BookId == postBookAdd.Id);
                if (userbook != null)
                {
                    return Conflict(new { message = $" '{book.Name}' kitabı kitaplığınızda zaten kayıtlı." });
                }
                if (book.Amount < 1)
                {
                    //return Content("Miktar Yetersiz!");
                    return Problem("Miktar Yetersiz!", statusCode: StatusCodes.Status304NotModified);
                }
                var userBook = new UserBooks()
                {
                    Amount = 1,
                    AppUser = appUser,
                    AppUserId = appUser.Id,
                    Book = book,
                    BookId = book.Id,
                    ReservationDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(7)
                };
                await _userBookService.AddAsync(userBook);
                book.Amount -= 1;
                _bookService.Update(book);
                //return Ok(new { id = appUser.Id, appUser = appUser, postBookAdd = postBookAdd, message = "İşlem Başarılı" });
                return Ok(postBookAdd);//
            }
            catch
            {
                return Problem("Hata Oluştu!");
            }

        }
        [HttpPost("PostBookRemove")]
        public async Task<ActionResult<PostBookAdd>> PostBookRemoveAsync(PostBookAdd postBookAdd)//[FromBody] 
        {

            var appUser = await _context.SingleOrDefaultAsync(x => x.RefreshToken == postBookAdd.RefreshToken);

            if (appUser == null)
            {
                return NotFound();
            }
            var book = await _bookService.GetByIdAsync(postBookAdd.Id);

            if (book == null)
            {
                return NotFound();
            }
            var userBook = await _userBookService.FirstOrDefaultAsync(u => u.BookId == book.Id && u.AppUserId == appUser.Id);
            _userBookService.Remove(userBook);
            book.Amount += 1;
            _bookService.Update(book);
            //return Ok(new { id = appUser.Id, appUser = appUser, postBookAdd = postBookAdd, message = "İşlem Başarılı" });
            return Ok(postBookAdd);
            try
            { }
            catch
            {
                return Problem("Hata Oluştu!");
            }

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

        [HttpGet("GetMyBooks")]
        public async Task<IEnumerable<UserBooks>> GetBooks([FromQuery] string token)
        {
            var list = await _userBookService.GetAllBooksByUsersAsync(u => u.AppUser.RefreshToken == token);
            return list;
        }
    }
}
