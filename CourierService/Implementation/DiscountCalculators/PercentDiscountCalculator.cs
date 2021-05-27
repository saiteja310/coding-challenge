using CourierService.Exceptions;
using CourierService.Interfaces;
using CourierService.Models;
using CourierService.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.DiscountCalculators
{
    public class PercentDiscountCalculator : IDiscountCalculator
    {
        public DiscountCouponType DiscountCouponType => DiscountCouponType.PERCENT;

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
            return (price * couponValue / 100);
        }
    }
}