using KitApp.Core.Entities;
using KitApp.WebAPI.Application.UserOperations.Commands.CreateToken;

namespace KitApp.WebAPI.Models
{
    public class HomePageViewModel
    {
        public AppUser AppUser { get; set; }
        public CreateTokenModel CreateTokenModel { get; set; }
    }
}
