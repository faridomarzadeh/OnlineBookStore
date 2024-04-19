using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.GeneralEntities.Banner.Edit
{
    public class EditBannerCommandValidator: AbstractValidator<EditBannerCommand>
    {
        public EditBannerCommandValidator()
        {
            RuleFor(c => c.ImageFile).JustImageFile();
            RuleFor(c => c.Link).NotEmpty().WithMessage(ValidationMessages.required("لینک")).NotNull();
        }
    }
}
