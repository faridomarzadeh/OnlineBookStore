using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommandValidator:AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام"));

            RuleFor(c => c.Family)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(c => c.City)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("شهر"));

            RuleFor(c => c.Province)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("استان"));

            RuleFor(c => c.PostalCode)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("کدپستی"));

            RuleFor(c => c.MailingAddress)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("آدرس پستی"));

            RuleFor(c => c.PhoneNumber)
              .NotNull()
              .NotEmpty()
              .WithMessage(ValidationMessages.required("شماره موبایل"))
              .Length(11)
              .WithMessage("شماره موبایل نامعتبر است");

            RuleFor(c => c.NationalID)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("کد ملی"))
               .Length(10)
               .WithMessage("کد ملی نامعتبر است")
               .ValidNationalID();
        }
    }
}
