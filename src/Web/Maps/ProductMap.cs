namespace Web.Infra.Maps
{
    using Features.Product;
    using FluentNHibernate.Mapping;

    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).Column("id").GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Price);
        }
    }
}