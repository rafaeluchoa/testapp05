namespace Naskar.Documents.Impl.Validators
{
    using FluentValidation;

    using Naskar.Documents.Domain;

    using Spring.AutoRegistration;

    [Named]
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(3, 50);
        }
    }
}
