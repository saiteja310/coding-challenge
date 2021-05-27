﻿using CourierService.Exceptions;
using CourierService.Interfaces;
using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.DiscountCalculators
{
    public class PercentDiscountCalculator : IPercentDiscountCalculator
    {
        public double CalculateDiscount(double price, double couponValue)
        {
            if (couponValue < 0)
            {
                throw new InvalidCouponPercentageException();
            }
            if (price < 0)
            {
                throw new InvalidPriceException();
            }
            return price - (price * couponValue / 100);
        }
    }
}