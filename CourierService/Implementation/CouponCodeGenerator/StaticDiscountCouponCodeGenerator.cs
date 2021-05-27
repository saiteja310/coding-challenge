using CourierService.Implementation.DiscountValidationRules;
using CourierService.Interfaces;
using CourierService.Models;
using CourierService.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.CouponCodeGenerator
{
    public class StaticDiscountCouponCodeGenerator : IDiscountCouponCodeGenerator
    {
        private readonly DistanceValidationRulesFactory _distanceValidationRules;

        private readonly WeightValidationRulesFactory _weightValidationRules;
        public StaticDiscountCouponCodeGenerator(DistanceValidationRulesFactory distanceValidationRules,
            WeightValidationRulesFactory weightValidationRules)
        {
            _distanceValidationRules = distanceValidationRules;
            _weightValidationRules = weightValidationRules;
        }

        public IDictionary<string, DiscountCouponCode> GenerateDiscountCouponCodes()
        {
            var couponCodes = new List<DiscountCouponCode>();
            couponCodes.Add(new DiscountCouponCode("OFR001", 10, DiscountCouponType.PERCENT, new List<IDiscountValidationRule>()
            {
                _distanceValidationRules.CreateLessThanDistanceRule(200),
                _weightValidationRules.CreateInBetweenWeightRule(70, 200)
            }));
            couponCodes.Add(new DiscountCouponCode("OFR002", 7, DiscountCouponType.PERCENT, new List<IDiscountValidationRule>()
            {
                _distanceValidationRules.CreateInBetweenDistanceRule(50, 150),
                _weightValidationRules.CreateInBetweenWeightRule(100, 250)
            }));
            couponCodes.Add(new DiscountCouponCode("OFR003", 5, DiscountCouponType.PERCENT, new List<IDiscountValidationRule>()
            {
                _distanceValidationRules.CreateInBetweenDistanceRule(50, 250),
                _weightValidationRules.CreateInBetweenWeightRule(10, 150)
            }));

            return couponCodes.ToDictionary(e => e.Code, e => e);
        }
    }
}