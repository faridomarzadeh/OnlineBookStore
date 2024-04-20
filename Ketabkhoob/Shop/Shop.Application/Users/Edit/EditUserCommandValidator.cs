using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(c => c.PhoneNumber).ValidPhoneNumber();

            RuleFor(c => c.Email).EmailAddress().WithMessage("ایمیل نامعتبر است");

            RuleFor(c => c.Password)
                .MinimumLength(4).WithMessage("کلمه عبور باید بیشتر از 4 کاراکتر باشد");

            RuleFor(f => f.Avatar)
                .JustImageFile();
        }
    }
}
