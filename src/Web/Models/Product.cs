namespace Web.Models
{
    using System.Collections.Generic;
    using Felice.Core.Model;

    public class Product : Entity
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string MainImage { get; set; }
        public virtual bool HasImage { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
    }
}