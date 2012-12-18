namespace Naskar.Architecture.Data
{
    using System.Collections.Generic;

    using Naskar.Architecture.Domain;
    using Naskar.QueryOverSpec;

    public interface IRepository
    {
        TEntity Find<TEntity>(long? id) where TEntity : Entity;

        IList<TEntity> Find<TEntity>() where TEntity : Entity;

        IList<TEntity> Find<TEntity>(ISpecification<TEntity> spec) where TEntity : Entity;

        void Add<TEntity>(TEntity entity) where TEntity : Entity;

        TEntity Modify<TEntity>(TEntity entity) where TEntity : Entity;

        void Remove<TEntity>(TEntity entity) where TEntity : Entity;

        void RemoveAll<TEntity>() where TEntity : Entity;
    }
}
