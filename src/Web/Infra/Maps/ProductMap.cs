using FluentNHibernate.Mapping;
using Web.Models;

namespace Web.Infra.Maps
{
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