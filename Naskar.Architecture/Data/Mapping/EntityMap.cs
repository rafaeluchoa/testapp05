namespace Naskar.Architecture.Data.Mapping
{
    using FluentNHibernate.Mapping;

    using Naskar.Architecture.Domain;

    public class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        public EntityMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();

            Version(x => x.Version);

            Map(x => x.Created);

            Map(x => x.Changed);
        }
    }
}
