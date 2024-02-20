using ETradeAPI.Application.ViewModels.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductCreateViewModel>
    {
        public CreateProductValidator()
        {

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün adı boş bırakılamaz!")
                .MaximumLength(30)
                .MinimumLength(3)
                .WithMessage("Ürün adı minimum 3 karakter ila maximum 30 karakter arsında olmalıdır!");

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Stok miktarı boş bırakılamaz!")
                .Must(s => s >= 0).WithMessage("Stock miktarı minimum 0 olabilir!");

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Ürün fiyatı boş bırakılamaz!")
                .Must(s => s > 0).WithMessage("Ürün fiyatı 0 dan büyük olmalıdır!");

        }
    }
}
