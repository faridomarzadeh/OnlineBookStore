using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommandValidator:AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
