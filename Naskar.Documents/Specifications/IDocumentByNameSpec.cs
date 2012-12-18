namespace Naskar.Documents.Specifications
{
    using Naskar.Documents.Domain;
    using Naskar.QueryOverSpec;

    public interface IDocumentByNameSpec
    {
        ISpecification<Document> By(string name);
    }
}
