using CourierService.Implementation.CouponCodeGenerator;
using CourierService.Implementation.DiscountValidationRules;
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
        IDiscountCouponCodeGenerator generator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var distance = new DistanceValidationRulesFactory();
            var weight = new WeightValidationRulesFactory();
            generator = new StaticDiscountCouponCodeGenerator(distance, weight);
        }


        [TestCase("OFR001", true)]
        [TestCase("OFR002", true)]
        [TestCase("OFR003", true)]
        [TestCase("OFR004", false)]
        [TestCase("", false)]
        public void TestStaticDiscountCouponCodeGenerator(string key, bool expected)
        {
            var result = generator.GenerateDiscountCouponCodes();
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(expected, result.ContainsKey(key));
        }

        [TestCase("OFR001", 10, DiscountCouponType.PERCENT)]
        [TestCase("OFR002", 7, DiscountCouponType.PERCENT)]
        [TestCase("OFR003", 5, DiscountCouponType.PERCENT)]
        public void TestStaticDiscountCouponCodeGeneratorValue(string key, decimal expectedValue, DiscountCouponType type)
        {
            var result = generator.GenerateDiscountCouponCodes();
            Assert.IsTrue(result.ContainsKey(key));
            Assert.AreEqual(key, result[key].Code);
            Assert.AreEqual(expectedValue, result[key].Value);
            Assert.AreEqual(type, result[key].DiscountCouponType);
        }
    }
}
