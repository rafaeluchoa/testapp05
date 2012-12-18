
namespace Naskar.Documents.Web.Models.Validators
{
    using FluentValidation;

    using Naskar.Documents.Impl.Validators;

    public class DocumentEntityModelValidator : AbstractValidator<DocumentEntityModel>
    {
        public DocumentEntityModelValidator()
        {
            // TODO: inject
            RuleFor(x => x.Value).SetValidator(new DocumentValidator());
        }
    }
}