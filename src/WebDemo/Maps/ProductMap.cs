namespace WebDemo.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            this.Table("product");
            this.Id(x => x.Id).Column("id").GeneratedBy.Native();
            this.Map(x => x.Name).Column("name");
            this.Map(x => x.Price).Column("price");
        }
    }
}