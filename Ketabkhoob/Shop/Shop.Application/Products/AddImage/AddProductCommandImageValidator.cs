using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddProductCommandImageValidator:AbstractValidator<AddProductCommandImage>
    {
        public AddProductCommandImageValidator()
        {
            RuleFor(x => x.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(x => x.Sequence).GreaterThanOrEqualTo(0);
        }
    }
}
