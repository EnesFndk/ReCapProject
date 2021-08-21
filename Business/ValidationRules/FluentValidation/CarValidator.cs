using Entities.Contrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(q => q.Description).MinimumLength(2);
            RuleFor(q => q.Description).NotEmpty();
            RuleFor(q => q.DailyPrice).NotEmpty();
            RuleFor(q => q.DailyPrice).GreaterThan(0);
            RuleFor(q => q.DailyPrice).GreaterThanOrEqualTo(10).When(q=> q.BrandId == 1);
            RuleFor(q => q.Description).Must(StartWithC).WithMessage("Ürünler C harfi ile Başlamalı");
        }

        private bool StartWithC(string arg)
        {
            return arg.StartsWith("C");
        }
    }
}
