using CourierService.Interfaces;
using CourierService.Models;
using CourierService.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.DiscountValidationRules
{
    public class DistanceValidationRulesFactory
    {
        private ValidationRuleType Type => ValidationRuleType.DISTANCE;
        public IDiscountValidationRule CreateGreaterThanDistanceRule(double value)
        {
            return new GreaterThanValidator(Type, value);
        }

        public IDiscountValidationRule CreateInBetweenDistanceRule(double lowerBound, double upperBound)
        {
            return new InBetweenValidator(Type, lowerBound, upperBound);
        }

        public IDiscountValidationRule CreateLessThanDistanceRule(double value)
        {
            return new LessThanValidator(Type, value);
        }
    }

    public class WeightValidationRulesFactory
    {
        private ValidationRuleType Type => ValidationRuleType.WEIGHT;
        public IDiscountValidationRule CreateGreaterThanWeightRule(double value)
        {
            return new GreaterThanValidator(Type, value);
        }

        public IDiscountValidationRule CreateInBetweenWeightRule(double lowerBound, double upperBound)
        {
            return new InBetweenValidator(Type, lowerBound, upperBound);
        }

        public IDiscountValidationRule CreateLessThanWeightRule(double value)
        {
            return new LessThanValidator(Type, value);
        }
    }
}
