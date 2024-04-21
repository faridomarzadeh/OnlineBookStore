using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommandValidator : AbstractValidator<AddUserAddressCommand>
    {
        public AddUserAddressCommandValidator()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage(ValidationMessages.required("شهر"));
            RuleFor(c => c.Province)
    .NotEmpty().WithMessage(ValidationMessages.required("استان"));
            RuleFor(c => c.Name)
    .NotEmpty().WithMessage(ValidationMessages.required("نام"));
            RuleFor(c => c.Family)
    .NotEmpty().WithMessage(ValidationMessages.required("فامیل"));
            RuleFor(c => c.MailingAddress)
    .NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));
            RuleFor(c => c.PostalCode)
.NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));

            RuleFor(c => c.NationalID)
.NotEmpty().WithMessage(ValidationMessages.required("کدملی"));
        }
    }
}
