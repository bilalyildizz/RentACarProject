using Entities.Concrete;
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
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(10);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(15).When(c => c.BrandId == 1);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("A ile başlamalı.");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
