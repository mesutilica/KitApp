using System;
using System.ComponentModel.DataAnnotations;

namespace KitApp.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Display(Name = "Ad")]
        public string Name { get; set; }
        [StringLength(50), Display(Name = "Soyad")]
        public string SurName { get; set; }
        [StringLength(50), DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [StringLength(150), Display(Name = "Şifre"), DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(15), Display(Name = "Telefon"), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        public Guid ActivateGuid { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
    }
}
