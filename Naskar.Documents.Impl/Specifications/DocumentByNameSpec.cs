namespace Naskar.Documents.Impl.Specifications
{
    using System;
    using Naskar.Documents.Domain;
    using Naskar.Documents.Specifications;
    using Naskar.QueryOverSpec;
    using NHibernate;

    using Spring.AutoRegistration;

    [Named]
    public class DocumentByNameSpec : IDocumentByNameSpec
    {
        public ISpecification<Document> By(string name)
        {
            ISpecification<Document> spec = new NoRestrictionsSpecification<Document>();

            if (!string.IsNullOrEmpty(name))
            {
                Action<IQueryOver<Document, Document>> action =
                    x => x.WhereRestrictionOn(e => e.Name).IsInsensitiveLike(name);

                spec = new QueryOverSpecification<Document>(action);
            }

            return spec;
        }
    }
}
