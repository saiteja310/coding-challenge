using CourierService.Interfaces;
using CourierService.Models;
using CourierService.Models.Enum;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CourierService.Tests")]
namespace CourierService.Implementation.DiscountValidationRules
{
    internal class InBetweenValidator : IDiscountValidationRule
    {
        private readonly double _lowerBound = 0.0;
        private readonly double _upperBound = 0.0;
        private readonly ValidationRuleType _type;
        public InBetweenValidator(ValidationRuleType type, double lowerBound, double upperBound)
        {
            _lowerBound = lowerBound;
            _upperBound = upperBound;
            _type = type;
        }
        public bool Validate(Package package)
        {
            return _type switch
            {
                ValidationRuleType.WEIGHT => package.Weight >= _lowerBound && package.Weight <= _upperBound,
                ValidationRuleType.DISTANCE => package.DistanceInKm >= _lowerBound && package.DistanceInKm <= _upperBound,
                _ => false,
            };
        }
    }
}