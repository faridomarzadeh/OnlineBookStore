using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.GeneralEntities.Banner.Create
{
    public class CreateBannerCommandValidator: AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(c => c.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();
            RuleFor(c => c.Link).NotEmpty().WithMessage(ValidationMessages.required("لینک")).NotNull();
        }
    }
}
