using CourierService.Interfaces;
using CourierService.Models;
using CourierService.Models.Enum;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CourierService.Tests")]
namespace CourierService.Implementation.DiscountValidationRules
{
    internal class GreaterThanValidator : IDiscountValidationRule
    {
        private readonly double _value;
        private readonly ValidationRuleType _type;
        public GreaterThanValidator(ValidationRuleType type, double value)
        {
            _value = value;
            _type = type;
        }
        public bool Validate(Package package)
        {
            return _type switch
            {
                ValidationRuleType.WEIGHT => _value > package.Weight,
                ValidationRuleType.DISTANCE => _value > package.DistanceInKm,
                _ => false,
            };
        }
    }
}