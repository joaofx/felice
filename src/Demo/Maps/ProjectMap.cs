namespace Demo.Maps
{
    using FluentNHibernate.Mapping;
    using Models;

    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("projects");
            Id(x => x.Id).Column("id").GeneratedBy.Native();
            Map(x => x.Name).Column("name");
        }
    }
}