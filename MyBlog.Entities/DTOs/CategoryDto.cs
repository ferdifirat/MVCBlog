namespace MyBlog.Entities.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string PictureUrl { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}