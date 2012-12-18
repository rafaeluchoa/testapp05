
namespace Naskar.Documents.Web.Models
{
    using FluentValidation.Attributes;

    using Naskar.Architecture.Web.Models;
    using Naskar.Documents.Domain;
    using Naskar.Documents.Web.Models.Validators;

    [Validator(typeof(DocumentEntityModelValidator))]
    public class DocumentEntityModel : EntityModel<Document>
    {
    }
}