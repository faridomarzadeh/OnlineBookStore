using Common.Application;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long SellerId,string ShopName,string NationalCode):IBaseCommand;

    public class EditSellerCommandValidator: AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidator()
        {
            RuleFor(c => c.ShopName).NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(c => c.NationalCode).NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
                .ValidNationalID();
        }
    }
}
