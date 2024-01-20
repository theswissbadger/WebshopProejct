namespace M295_Project_V1._0.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; } = null!;
        public string? Description { get; set; }
        public float? Price { get; set; }
    }
}
