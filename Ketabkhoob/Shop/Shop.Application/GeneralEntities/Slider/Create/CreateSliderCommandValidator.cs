using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.GeneralEntities.Slider.Create
{
    public class CreateSliderCommandValidator: AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(c => c.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();
            RuleFor(c => c.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(c => c.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        }
    }
}
