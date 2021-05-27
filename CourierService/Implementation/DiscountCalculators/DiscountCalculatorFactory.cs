using CourierService.Interfaces;
using CourierService.Models;
using CourierService.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.DiscountCalculators
{
    public class DiscountCalculatorFactory
    {
        private IDictionary<DiscountCouponType, IDiscountCalculator> _discountCalculators;
        public DiscountCalculatorFactory(IEnumerable<IDiscountCalculator> discountCalculators)
        {
            _discountCalculators = discountCalculators.ToDictionary(e => e.DiscountCouponType, e => e);
        }
        public double CalculateDiscount(double price, DiscountCouponCode discount)
        {
            if (discount is null)
            {
                return price;
            }
            return _discountCalculators[discount.DiscountCouponType].CalculateDiscount(price, discount.Value);
        }
    }
}
