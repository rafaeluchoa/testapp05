namespace Naskar.Architecture.Specification
{
    using Naskar.Architecture.Data;
    using Naskar.Architecture.Domain;
    using Naskar.QueryOverSpec;

    public interface IPageSpec
    {
        ISpecification<T> By<T>(PageContext pageContext)
            where T : Entity;
    }
}
