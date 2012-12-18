namespace Naskar.Documents.Domain
{
    using Naskar.Architecture.Domain;

    public class Section : Entity
    {
        public virtual Document Document { get; set; }
    }
}
