using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KitApp.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Soyad")]
        public string SurName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Şifre"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Telefon"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        /*public List<Book> Books { get; set; }
        public AppUser()
        {
            Books = new List<Book>();
        }*/
    }
}
