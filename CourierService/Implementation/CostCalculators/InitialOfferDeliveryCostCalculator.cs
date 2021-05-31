using CourierService.Exceptions;
using CourierService.Implementation.DiscountCalculators;
using CourierService.Interfaces;
using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.CostCalculators
{
    public sealed class InitialOfferDeliveryCostCalculator : DeliveryCostCalculator
    {
        private readonly int MAX_APPLICABLE_DISCOUNTS = 1;

        private readonly ICouponCodeService _couponCodeService;

        private readonly DiscountCalculatorFactory _discountCalculatorFactory;
        public InitialOfferDeliveryCostCalculator(ICouponCodeService couponCodeValidator, DiscountCalculatorFactory discountCalculatorFactory)
        {
            _couponCodeService = couponCodeValidator;
            _discountCalculatorFactory = discountCalculatorFactory;
        }

        public override double Calculate()
        {
            var coupon = _couponCodeService.GetCouponCode(Discounts.FirstOrDefault());

            double totalPrice = BasePrice + (Package.Weight * 10) + (Package.DistanceInKm * 5);
            double discount = 0;
            if (_couponCodeService.ValidateCouponCode(Package, coupon))
            {
                discount = _discountCalculatorFactory.CalculateDiscount(totalPrice, coupon);
            }
            totalPrice -= discount;
            LogData(Package.PackageName, discount, totalPrice);
            return totalPrice;
        }

        private void LogData(string packageName, double discount, double totalPrice)
        {
            if (IsLoggingEnabled)
            {
                System.Console.WriteLine($"{packageName} {discount} {totalPrice}");
            }
        }

        public override IDeliveryCostCalculator WithDiscounts(IEnumerable<IDiscount> discounts)
        {
            int count = discounts.Count();
            if (count > MAX_APPLICABLE_DISCOUNTS)
            {
                throw new CouponCodesAppliedBeyondLimit(count, MAX_APPLICABLE_DISCOUNTS);
            }
            return base.WithDiscounts(discounts);
        }
    }
}
