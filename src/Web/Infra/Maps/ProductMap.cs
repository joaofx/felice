namespace Web.Infra.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

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