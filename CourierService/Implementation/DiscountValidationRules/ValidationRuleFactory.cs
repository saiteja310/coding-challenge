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
    public static class DistanceValidationRulesFactory
    {
        public static IDiscountValidationRule CreateGreaterThanDistanceRule(double value)
        {
            return new GreaterThanValidator(ValidationRuleType.DISTANCE, value);
        }

        public static IDiscountValidationRule CreateInBetweenDistanceRule(double lowerBound, double upperBound)
        {
            return new InBetweenValidator(ValidationRuleType.DISTANCE, lowerBound, upperBound);
        }

        public static IDiscountValidationRule CreateLessThanDistanceRule(double value)
        {
            return new LessThanValidator(ValidationRuleType.DISTANCE, value);
        }
    }

    public static class WeightValidationRulesFactory
    {
        public static IDiscountValidationRule CreateGreaterThanWeightRule(double value)
        {
            return new GreaterThanValidator(ValidationRuleType.WEIGHT, value);
        }

        public static IDiscountValidationRule CreateInBetweenWeightRule(double lowerBound, double upperBound)
        {
            return new InBetweenValidator(ValidationRuleType.WEIGHT, lowerBound, upperBound);
        }

        public static IDiscountValidationRule CreateLessThanWeightRule(double value)
        {
            return new LessThanValidator(ValidationRuleType.WEIGHT, value);
        }
    }
}
