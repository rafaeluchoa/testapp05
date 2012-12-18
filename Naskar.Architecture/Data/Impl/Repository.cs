namespace Naskar.Architecture.Data.Impl
{
    using System.Collections.Generic;
    using Naskar.Architecture.Domain;
    using Naskar.QueryOverSpec;
    using Naskar.QueryOverSpec.Impl;
    using NHibernate;

    using Spring.AutoRegistration;

    [Named]
    public class Repository : IRepository
    {
        [Inject]
        public ISessionFactory SessionFactory { protected get; set; }

        protected ISession Session
        {
            get
            {
                return SessionFactory.GetCurrentSession();
            }
        }

        public IList<TEntity> Find<TEntity>(ISpecification<TEntity> spec)
            where TEntity : Entity
        {
            var query = Session.QueryOver<TEntity>();

            var visitor = new QueryOverSpecificationVisitor<TEntity>(query);
            spec.Accept(visitor);

            var list = query.List();

            return list;
        }

        public IList<TEntity> Find<TEntity>() where TEntity : Entity
        {
            return Session.QueryOver<TEntity>().List();
        }

        public TEntity Find<TEntity>(long? id) where TEntity : Entity
        {
            return Session.Get<TEntity>(id);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            Session.Save(entity);
        }

        public TEntity Modify<TEntity>(TEntity entity) where TEntity : Entity
        {
            return Session.Merge(entity);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : Entity
        {
            var obj = Session.Merge(entity);
            Session.Delete(obj);
        }

        public void RemoveAll<TEntity>() where TEntity : Entity
        {
            foreach (var item in Find<TEntity>())
            {
                this.Remove(item);
            }
        }
    }
}
