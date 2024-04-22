using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommandValidator:AbstractValidator<ChargeUserWalletCommand>
    {
        public ChargeUserWalletCommandValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(c => c.Price).GreaterThanOrEqualTo(500);
        }
    }
}
