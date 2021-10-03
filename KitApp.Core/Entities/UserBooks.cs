using System;
using System.ComponentModel.DataAnnotations;

namespace KitApp.Core.Entities
{
    public class UserBooks : IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        [Display(Name = "Kitap")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [Display(Name = "Miktar")]
        public int Amount { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
