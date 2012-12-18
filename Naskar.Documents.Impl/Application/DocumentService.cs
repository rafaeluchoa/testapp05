namespace Naskar.Documents.Impl.Application
{
    using System.Collections.Generic;

    using Naskar.Architecture.Data;
    using Naskar.Architecture.Specification;
    using Naskar.Documents.Application;
    using Naskar.Documents.Application.VO;
    using Naskar.Documents.Domain;
    using Naskar.Documents.Specifications;

    using Spring.AutoRegistration;

    [Named]
    public class DocumentService : IDocumentService
    {
        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IPageSpec PageSpec { get; set; }

        [Inject]
        public IDocumentByNameSpec DocumentByNameSpec { get; set; }

        public IList<Document> ListByName(DocumentListVO vo, PageContext pageContext)
        {
            return Repository.Find(DocumentByNameSpec.By(vo.Name));
        }

        public Document Get(long id)
        {
            return Repository.Find<Document>(id);
        }

        public void InsertInterno(Document document)
        {
            Repository.Add(new Document() { Name = document.Name + "clone" });
        }

        public void Insert(Document document)
        {
            this.InsertInterno(document);

            Repository.Add(document);
        }

        public void Modify(Document document)
        {
            Repository.Modify(document);
        }

        public void Remove(IList<Document> documents)
        {
            foreach (var document in documents)
            {
                Repository.Remove(document);    
            }
        }
    }
}
