
namespace Naskar.Documents.Web.Controllers
{
    using System.Web.Mvc;

    using Naskar.Architecture.Data;
    using Naskar.Architecture.Web.Models;
    using Naskar.Documents.Application;
    using Naskar.Documents.Domain;
    using Naskar.Documents.Web.Models;

    using Spring.AutoRegistration;

    public class DocumentController : Controller
    {
        [Inject]
        public IDocumentService DocumentService { get; set; }

        public ActionResult Index()
        {
            return this.Search(new DocumentListModel(), new PageContext());
        }

        public ActionResult Search(DocumentListModel listModel, PageContext pageContext)
        {
            listModel.Documents = new ListModel<Document>(DocumentService.ListByName(listModel.VO, pageContext));

            return View("Search", listModel);
        }

        public ActionResult Add()
        {
            return View("Edit", new DocumentEntityModel());
        }

        public ActionResult Edit(long id)
        {
            var entity = DocumentService.Get(id);
            if (entity == null)
            {
                return this.HttpNotFound();
            }

            var entityModel = new DocumentEntityModel();
            entityModel.Value = entity;

            return View("Edit", entityModel);
        }

        public ActionResult Save(DocumentEntityModel entityModel)
        {
            if (entityModel.New)
            {
                DocumentService.Insert(entityModel.Value);
            }
            else
            {
                DocumentService.Modify(entityModel.Value);
            }

            return Json(new { script = "window.location='" + Url.Action("Index") + "';" });
        }

        public ActionResult Remove(DocumentListModel listModel)
        {
            DocumentService.Remove(listModel.Documents.GetSelected());
            return this.Search(listModel, new PageContext());
        }
    }
}
