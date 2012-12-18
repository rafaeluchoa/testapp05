
namespace Naskar.Documents.Domain
{
    using Naskar.Architecture.Domain;

    public class Document : Entity
    {
        public virtual string Name { get; set; }

        public virtual decimal PaidValue { get; set; }
    }
}
