namespace roksh.Models
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ItemUrl { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}