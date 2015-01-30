namespace Web.Models
{
    using Felice.Core.Model;

    public class ProductImage : Entity
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
    }
}