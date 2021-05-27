using CourierService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.DiscountCalculators
{
    public class PercentDiscountCalculator : IPercentDiscountCalculator
    {
        public IEnumerable<IDiscountValidationRule> DiscountValidationRules { get; }

        public PercentDiscountCalculator(IEnumerable<IDiscountValidationRule> discountValidationRules)
        {
            DiscountValidationRules = discountValidationRules;
        }

        public decimal CalculateDiscount()
        {
            return 0.0M;
        }
    }
}