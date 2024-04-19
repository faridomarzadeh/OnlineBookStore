using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.GeneralEntities.Slider.Edit
{
    public class EditSliderCommandValidator: AbstractValidator<EditSliderCommand>
    {
        public EditSliderCommandValidator()
        {
            RuleFor(c => c.ImageFile).JustImageFile();

            RuleFor(c => c.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(c => c.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        }
    }
}
