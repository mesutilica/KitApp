using System;
using KitApp.Core.Entities;
using KitApp.Core.Services;
using KitApp.WebAPI.TokenOperations;
using KitApp.WebAPI.TokenOperations.Models;
using Microsoft.Extensions.Configuration;

namespace KitApp.WebAPI.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly IAppUserService _context;
        private readonly IConfiguration _configuration;
        public string RefreshToken;
        public RefreshTokenCommand(IAppUserService context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public Token Handle()
        {
            AppUser user = _context.SingleOrDefaultAsync(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now).Result;
            if (user is not null)
            {

                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(30);
                _context.Update(user);
               // _context.SaveChangesAsync();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid Refresh Token Bulunamadı");
            }
        }
    }
}
