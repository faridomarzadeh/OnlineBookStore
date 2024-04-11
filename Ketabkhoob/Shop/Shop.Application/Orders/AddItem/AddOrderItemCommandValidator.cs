using FluentValidation;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandValidator:AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
        {
            RuleFor(c => c.Count).GreaterThanOrEqualTo(1)
                .WithMessage("تعداد نباید کمتر از یک باشد");
        }
    }
}
