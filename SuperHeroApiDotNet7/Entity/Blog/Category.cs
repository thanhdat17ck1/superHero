namespace SuperHeroApiDotNet7.Entity.Blog
{
    public class CategoryEntity
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? Slug { set; get; }
        public int? ParentCategoryId { get; set; }
    }
    public class Category : CategoryEntity
    {
        public Category? ParentCategory { set; get; }
    }
}
