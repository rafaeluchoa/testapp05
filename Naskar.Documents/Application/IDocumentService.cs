namespace Naskar.Documents.Application
{
    using System.Collections.Generic;

    using Naskar.Architecture.Data;
    using Naskar.Documents.Application.VO;
    using Naskar.Documents.Domain;

    public interface IDocumentService
    {
        IList<Document> ListByName(DocumentListVO vo, PageContext pageContext);

        Document Get(long id);

        void Insert(Document document);

        void Modify(Document document);

        void Remove(IList<Document> documents);
    }
}
