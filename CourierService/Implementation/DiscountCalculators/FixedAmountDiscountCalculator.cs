using CourierService.Exceptions;
using CourierService.Interfaces;
using CourierService.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.DiscountCalculators
{
    public class FixedAmountDiscountCalculator : IDiscountCalculator
    {
        public DiscountCouponType DiscountCouponType => DiscountCouponType.FIXED_AMOUNT;

        public double CalculateDiscount(double price, double couponValue)
        {
            if (couponValue < 0)
            {
                throw new InvalidCouponPercentageException();
            }
            if (price < 0)
            {
                throw new InvalidPriceException(price);
            }
            var result = price - couponValue;
            return result < 0 ? 0 : result;
        }
    }
}
