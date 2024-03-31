namespace EasyProject.Models
{
    public class Properties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductProperties>? ProductProperties { get; set; }
    }
}
