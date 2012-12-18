namespace Naskar.Architecture.Specification.Impl
{
    using System;
    using Naskar.Architecture.Data;
    using Naskar.Architecture.Domain;
    using Naskar.QueryOverSpec;
    using NHibernate;

    using Spring.AutoRegistration;

    [Named]
    public class PageSpec : IPageSpec
    {
        public ISpecification<T> By<T>(PageContext pageContext)
            where T : Entity
        {
            Action<IQueryOver<T, T>> action = a =>
                {
                    var maxResults = pageContext.RowsByPage.GetValueOrDefault(10);
                    var firstResult = pageContext.CurrentePage.GetValueOrDefault() * maxResults;

                    if (maxResults > 0)
                    {
                        a.Skip(firstResult);    
                    }

                    if (firstResult > 0)
                    {
                        a.Take(maxResults);    
                    }
                };

            return new QueryOverSpecification<T>(action);
        }
    }
}
