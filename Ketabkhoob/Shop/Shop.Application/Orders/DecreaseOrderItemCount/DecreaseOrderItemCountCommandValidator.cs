using FluentValidation;

namespace Shop.Application.Orders.DecreaseOrderItemCount
{
    public class DecreaseOrderItemCountCommandValidator:AbstractValidator<DecreaseOrderItemCountCommand> 
    {
        public DecreaseOrderItemCountCommandValidator()
        {
            RuleFor(c => c.Count).GreaterThanOrEqualTo(1)
                .WithMessage("تعداد نباید کمتر از یک باشد");
        }
    }
}
