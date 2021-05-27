﻿using CourierService.Exceptions;
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

        private readonly ICouponCodeValidator _couponCodeValidator;

        private readonly DiscountCalculatorFactory _discountCalculatorFactory;
        public InitialOfferDeliveryCostCalculator(ICouponCodeValidator couponCodeValidator, DiscountCalculatorFactory discountCalculatorFactory)
        {
            _couponCodeValidator = couponCodeValidator;
            _discountCalculatorFactory = discountCalculatorFactory;
        }
        
        public override double Calculate()
        {
            var totalPrice = BasePrice + (Package.Weight * 10) + (Package.DistanceInKm * 5);
            var coupon = _couponCodeValidator.GetCouponCode(Discounts.FirstOrDefault());
            if (!_couponCodeValidator.ValidateCouponCode(Package, coupon))
            {
                return totalPrice;
            }
            totalPrice = _discountCalculatorFactory.ApplyDiscount(totalPrice, coupon);
            return totalPrice;
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