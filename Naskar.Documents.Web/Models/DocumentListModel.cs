
namespace Naskar.Documents.Web.Models
{
    using Naskar.Architecture.Web.Models;
    using Naskar.Documents.Application.VO;
    using Naskar.Documents.Domain;

    public class DocumentListModel
    {
        public DocumentListModel()
        {
            VO = new DocumentListVO();
            Documents = new ListModel<Document>();
        }

        public DocumentListVO VO { get; set; }

        public ListModel<Document> Documents { get; set; }
    }
}