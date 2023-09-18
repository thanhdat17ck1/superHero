namespace SuperHeroApiDotNet7.Entity.Blog
{
    public class PostEntity
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? Slug { set; get; }
        public string? Content { set; get; }
        public bool Published { get; set; }
        public int AuthorId { set; get; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
