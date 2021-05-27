using CourierService.Implementation.CouponCodeGenerator;
using CourierService.Interfaces;
using CourierService.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Tests.CouponCodeGenerators
{
    [TestFixture]
    class CouponCodeGeneratorTests
    {
        [TestCase("OFR001", true)]
        [TestCase("OFR002", true)]
        [TestCase("OFR003", true)]
        [TestCase("OFR004", false)]
        [TestCase(null, false)]
        public void TestStaticDiscountCouponCodeGenerator(string key, bool expected)
        {
            IDiscountCouponCodeGenerator generator = new StaticDiscountCouponCodeGenerator();
            var result = generator.GenerateDiscountCouponCodes();
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(expected, result.ContainsKey(key));
        }

        [TestCase("OFR001", 10, DiscountCouponType.PERCENT)]
        [TestCase("OFR002", 7, DiscountCouponType.PERCENT)]
        [TestCase("OFR003", 5, DiscountCouponType.PERCENT)]
        public void TestStaticDiscountCouponCodeGeneratorValue(string key, decimal expectedValue, DiscountCouponType type)
        {
            IDiscountCouponCodeGenerator generator = new StaticDiscountCouponCodeGenerator();
            var result = generator.GenerateDiscountCouponCodes();
            Assert.IsTrue(result.ContainsKey(key));
            Assert.AreEqual(key, result[key].Code);
            Assert.AreEqual(expectedValue, result[key].Value);
            Assert.AreEqual(type, result[key].DiscountCouponType);
        }
    }
}
