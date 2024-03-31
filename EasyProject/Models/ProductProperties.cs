namespace EasyProject.Models
{
    public class ProductProperties
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    } 
}
