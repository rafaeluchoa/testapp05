namespace Naskar.Documents.Impl.Mapping
{
    using Naskar.Architecture.Data.Mapping;
    using Naskar.Documents.Domain;

    public class DocumentMap : EntityMap<Document>
    {
        public DocumentMap()
        {
            Map(x => x.Name);

            Map(x => x.PaidValue);
        }
    }
}
