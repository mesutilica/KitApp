using System.ComponentModel.DataAnnotations;

namespace KitApp.Core.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kitap Adı")]
        public string Name { get; set; }
        [Display(Name = "Yazar Adı")]
        public string AuthorName { get; set; }
        [Display(Name = "Yayıncı Adı")]
        public string PublisherName { get; set; }
    }
}
