using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KitApp.Core.Entities;
using KitApp.Core.Services;
using Microsoft.Extensions.Configuration;
using KitApp.WebAPI.Application.UserOperations.Commands.CreateToken;
using KitApp.WebAPI.TokenOperations.Models;
using AutoMapper;
using KitApp.WebAPI.Application.UserOperations.Commands.RefreshToken;
using Microsoft.AspNetCore.Cors;

namespace KitApp.WebAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService _context;
        readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserController(IAppUserService context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        // POST: api/AppUsers
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            try
            {
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

        [HttpPost("connect/token")]
        public ActionResult<Token> Login(CreateTokenModel login)//[FromBody] 
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)//token a gelecek refreshToken değeri RefreshTokenCommand a gönderilip yenileniyor
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }

    }
}
