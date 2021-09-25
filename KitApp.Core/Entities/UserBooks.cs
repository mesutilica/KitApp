namespace KitApp.Core.Entities
{
    public class UserBooks : IEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
