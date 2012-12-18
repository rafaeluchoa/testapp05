namespace Naskar.Documents.Impl.Mapping
{
    using Naskar.Architecture.Data.Mapping;
    using Naskar.Documents.Domain;

    public class SectionMap : EntityMap<Section>
    {
        public SectionMap()
        {
            References(x => x.Document);
        }
    }
}
