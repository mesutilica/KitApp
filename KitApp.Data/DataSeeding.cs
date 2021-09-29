using KitApp.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KitApp.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<AppDbContext>();

            context.Database.Migrate(); // dotnet ef database update

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.AppUsers.Count() == 0)
                {
                    AppUser user = new AppUser()
                    {
                        Email = "admin@website.com",
                        IsActive = true,
                        Name = "Admin",
                        SurName = "Admin",
                        Password = "$2a$11$VHBxhufu7L4GVdfnl0xpieGMdb1j88guIlZOLvwo6vysYrW8JC61S",//123456
                        UserName = "admin",
                        CreateDate = DateTime.Now,
                    };
                    AppUser user2 = new AppUser()
                    {
                        Email = "user@website.com",
                        IsActive = true,
                        Name = "User",
                        SurName = "User",
                        Password = "$2a$11$VHBxhufu7L4GVdfnl0xpieGMdb1j88guIlZOLvwo6vysYrW8JC61S",//123456
                        UserName = "User",
                        CreateDate = DateTime.Now,
                    };
                    AppUser user3 = new AppUser()
                    {
                        Email = "guest@website.com",
                        IsActive = true,
                        Name = "Guset",
                        SurName = "Guset",
                        Password = "$2a$11$VHBxhufu7L4GVdfnl0xpieGMdb1j88guIlZOLvwo6vysYrW8JC61S",//123456
                        UserName = "Guset",
                        CreateDate = DateTime.Now,
                    };
                    context.AppUsers.Add(user);
                    context.AppUsers.Add(user2);
                    context.AppUsers.Add(user3);
                }
                if (!context.Books.Any())
                {
                    List<Book> books = new List<Book>()
                    {
                        new Book{Name = "Book 1 ", Amount = 3, AuthorName = "Test Author", PublisherName = "Test Publisher"},
                        new Book{Name = "Book 2 ", Amount = 1, AuthorName = "Test Author 2", PublisherName = "Test Publisher 2"},
                        new Book{Name = "Book 3 ", Amount = 5, AuthorName = "Test Author 3", PublisherName = "Test Publisher 3"},
                        new Book{Name = "Book 4 ", Amount = 1, AuthorName = "Test Author 4", PublisherName = "Test Publisher 4"},
                        new Book{Name = "Book 5 ", Amount = 5, AuthorName = "Test Author 5", PublisherName = "Test Publisher 5"},
                        new Book{Name = "Book 6 ", Amount = 1, AuthorName = "Test Author 6", PublisherName = "Test Publisher 6"},
                        new Book{Name = "Book 7 ", Amount = 5, AuthorName = "Test Author 7", PublisherName = "Test Publisher 7"},
                        new Book{Name = "Book 8 ", Amount = 1, AuthorName = "Test Author 8", PublisherName = "Test Publisher 8"},
                        new Book{Name = "Book 9 ", Amount = 5, AuthorName = "Test Author 9", PublisherName = "Test Publisher 9"}
                    };
                    context.Books.AddRange(books);
                }
                context.SaveChanges();//Buradan sonra startup.cs ye bu class ı ekle
            }
        }
    }
}
