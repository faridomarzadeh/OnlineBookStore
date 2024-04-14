using FluentValidation;

namespace Shop.Application.Orders.IncreaseOrderItemCount
{
    public class IncreaseOrderItemCountCommandValidator: AbstractValidator<IncreaseOrderItemCountCommand>
    {
        public IncreaseOrderItemCountCommandValidator()
        {
            RuleFor(c => c.Count).GreaterThanOrEqualTo(1)
                .WithMessage("تعداد نباید کمتر از یک باشد");
        }
    }
}
