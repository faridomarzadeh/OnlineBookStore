using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(c=>c.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
