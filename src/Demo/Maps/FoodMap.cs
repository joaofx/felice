namespace Demo.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class FoodMap : ClassMap<Food>
    {
        public FoodMap()
        {
            Table("food");
            Id(x => x.Id).Column("id").GeneratedBy.Native();
            Map(x => x.Name).Column("name");

            Map(x => x.Calories).Column("calories");
            Map(x => x.Carbs).Column("carbs");
            Map(x => x.Fats).Column("fats");
            Map(x => x.Proteins).Column("proteins");
        }
    }
}