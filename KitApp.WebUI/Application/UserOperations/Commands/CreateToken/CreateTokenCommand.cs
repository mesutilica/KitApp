using System.Linq;
using AutoMapper;
//using KitApp.WebAPI.DBOperations;
using KitApp.Core.Entities;
using KitApp.Core.Services;
using KitApp.WebAPI.TokenOperations;
using KitApp.WebAPI.TokenOperations.Models;
using Microsoft.Extensions.Configuration;

namespace KitApp.WebAPI.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly IAppUserService _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CreateTokenModel Model;
        public CreateTokenCommand(IAppUserService context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            AppUser user = _context.SingleOrDefaultAsync(x => x.Email == Model.Email && x.Password == Model.Password).Result;
            if (user is not null)
            {
                //Token üretiliyor.
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(30);
                _context.Update(user);
               // _context.SaveChangesAsync();

                return token;
            }
            return null;
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
