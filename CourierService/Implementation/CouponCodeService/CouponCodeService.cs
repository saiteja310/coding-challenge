using CourierService.Interfaces;
using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.CouponCodeService
{
    public class CouponCodeService : ICouponCodeService
    {
        private IDictionary<string, DiscountCouponCode> _discountCouponCodes;
        public CouponCodeService(IDiscountCouponCodeGenerator discountCouponCodeGenerator)
        {
            _discountCouponCodes = discountCouponCodeGenerator.GenerateDiscountCouponCodes();
        }

        public DiscountCouponCode GetCouponCode(IDiscount discount)
        {
            if (_discountCouponCodes.ContainsKey(discount.CouponCode))
            {
                return _discountCouponCodes[discount.CouponCode];
            }
            return null;
        }

        public bool ValidateCouponCode(Package package, DiscountCouponCode couponCode)
        {
            if (couponCode is null)
            {
                return false;
            }
            if (!_discountCouponCodes.ContainsKey(couponCode.Code))
            {
                return false;
            }
            var coupon = _discountCouponCodes[couponCode.Code];
            if (!coupon.DiscountValidationRules.All(e => e.Validate(package)))
            {
                return false;
            }
            return true;
        }
    }
}
