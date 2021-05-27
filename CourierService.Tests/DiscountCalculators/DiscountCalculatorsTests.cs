using CourierService.Exceptions;
using CourierService.Implementation.DiscountCalculators;
using CourierService.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Tests.DiscountCalculators
{
    [TestFixture]
    class DiscountCalculatorsTests
    {
        [TestCase(100, 0, 100)]
        [TestCase(100, 10, 90)]
        [TestCase(100, 99.5, 0.5)]
        [TestCase(100, 100, 0)]
        [TestCase(0, 10, 0)]
        [TestCase(99, 7.25, 91.8225)]
        public void TestPercentDiscountCalculator(double price, double couponValue, double expected)
        {
            IDiscountCalculator calculator = new PercentDiscountCalculator();
            Assert.AreEqual(expected, calculator.CalculateDiscount(price, couponValue));
        }

        [TestCase(-1, 10, typeof(InvalidPriceException))]
        [TestCase(10, -1, typeof(InvalidCouponPercentageException))]
        public void TestPercentDiscountCalculatorExceptions(double price, double couponValue, Type exceptionType)
        {
            IDiscountCalculator calculator = new PercentDiscountCalculator();
            Assert.Throws(exceptionType, () => calculator.CalculateDiscount(price, couponValue));
        }

        [TestCase(120, 0, 120)]
        [TestCase(120, 20, 100)]
        [TestCase(120, 99.5, 20.5)]
        [TestCase(100, 100, 0)]
        [TestCase(0, 10, 0)]
        [TestCase(99, 7.25, 91.75)]
        public void TestFixedDiscountCalculator(double price, double couponValue, double expected)
        {
            IDiscountCalculator calculator = new FixedAmountDiscountCalculator();
            Assert.AreEqual(expected, calculator.CalculateDiscount(price, couponValue));
        }

        [TestCase(-1, 10, typeof(InvalidPriceException))]
        [TestCase(10, -1, typeof(InvalidCouponPercentageException))]
        public void TestFixedDiscountCalculatorExceptions(double price, double couponValue, Type exceptionType)
        {
            IDiscountCalculator calculator = new FixedAmountDiscountCalculator();
            Assert.Throws(exceptionType, () => calculator.CalculateDiscount(price, couponValue));
        }
    }
}