using Felice.Core.Model;

namespace Web.Models
{
    public class Product : Entity
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Image { get; set; }
    }
}