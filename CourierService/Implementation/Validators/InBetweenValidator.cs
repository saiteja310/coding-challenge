using CourierService.Interfaces;
using CourierService.Models;
namespace CourierService.Implementation.Validators
{
    public class InBetweenValidator : IDiscountValidationRule
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