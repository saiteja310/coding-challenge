using CourierService.Implementation.CouponCodeGenerator;
using CourierService.Implementation.DiscountValidationRules;
using CourierService.Interfaces;
using CourierService.Models;
using CourierService.Models.Enum;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Tests.CouponCodeValidator
{
    [TestFixture]
    class CouponCodeValidatorTests
    {
        private Implementation.CouponCodeValidator.CouponCodeValidator _couponCodeValidator;
        private Mock<IDiscountCouponCodeGenerator> mockGenerator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SetRules();
        }

        private void SetRules(int rule = 0)
        {
            mockGenerator = new Mock<IDiscountCouponCodeGenerator>();
            mockGenerator.Setup(e => e.GenerateDiscountCouponCodes()).Returns(GetTestingCouponCodes(rule));
            _couponCodeValidator = new Implementation.CouponCodeValidator.CouponCodeValidator(mockGenerator.Object);
        }


        [TestCase("OFR001", true)]
        [TestCase("", false)]
        [TestCase("OFR002", true)]
        public void TestCouponCodeValidator_GetCouponCodeTests(string discountCode, bool isValid)
        {
            DiscountCouponCode coupon = _couponCodeValidator.GetCouponCode(new Discount(discountCode));
            Assert.AreEqual(isValid, coupon != null);
        }

        [TestCase("", 0, 0, false)]
        [TestCase("OFR001", 20, 20, false)]
        [TestCase("OFR002", 1, 1, true)]
        public void TestCouponCodeValidator_ValidateCouponCodeGTTests(string discountCode, double weight, double distance, bool expected)
        {
            SetRules(0);
            DiscountCouponCode coupon = _couponCodeValidator.GetCouponCode(new Discount(discountCode));
            Package package = new Package("OFR1Package", weight, distance);
            Assert.AreEqual(expected, _couponCodeValidator.ValidateCouponCode(package, coupon));
        }


        [TestCase("OFR001", 20, 20, true)]
        [TestCase("OFR002", 1, 1, false)]
        public void TestCouponCodeValidator_ValidateCouponCodeLTTests(string discountCode, double weight, double distance, bool expected)
        {
            SetRules(1);
            DiscountCouponCode coupon = _couponCodeValidator.GetCouponCode(new Discount(discountCode));
            Package package = new Package("OFR1Package", weight, distance);
            Assert.AreEqual(expected, _couponCodeValidator.ValidateCouponCode(package, coupon));
        }

        [TestCase("OFR001", 15, 15, true)]
        [TestCase("OFR001", 10, 10, true)]
        [TestCase("OFR001", 20, 20, true)]
        [TestCase("OFR002", 25, 25, false)]
        [TestCase("OFR002", 9, 9, false)]
        [TestCase("OFR002", 21, 21, false)]
        public void TestCouponCodeValidator_ValidateCouponCodeIBTests(string discountCode, double weight, double distance, bool expected)
        {
            SetRules(2);
            DiscountCouponCode coupon = _couponCodeValidator.GetCouponCode(new Discount(discountCode));
            Package package = new Package("OFR1Package", weight, distance);
            Assert.AreEqual(expected, _couponCodeValidator.ValidateCouponCode(package, coupon));
        }

        [Test]
        public void TestCouponCodeValidator_ValidateEquality()
        {
            var discountCouponCode1 = new DiscountCouponCode("1", 1, DiscountCouponType.PERCENT, null);
            var discountCouponCode2 = new DiscountCouponCode("2", 1, DiscountCouponType.PERCENT, null);
            var discountCouponCode3 = new DiscountCouponCode("1", 2, DiscountCouponType.FIXED_AMOUNT, null);
            var set = new HashSet<DiscountCouponCode>() { discountCouponCode1, discountCouponCode2, discountCouponCode3 };
            Assert.AreNotEqual(discountCouponCode1, discountCouponCode2);
            Assert.AreEqual(discountCouponCode1, discountCouponCode3);
            Assert.IsFalse(discountCouponCode1.Equals(discountCouponCode2));
            Assert.IsFalse(discountCouponCode1.Equals(null));
            Assert.IsTrue(discountCouponCode1.Equals(discountCouponCode3));
            Assert.AreEqual(2, set.Count);
        }

        private IDictionary<string, DiscountCouponCode> GetTestingCouponCodes(int validationRule = 0)
        {
            return new Dictionary<string, DiscountCouponCode>() {
                { "OFR001", new DiscountCouponCode("OFR001", 1, DiscountCouponType.PERCENT, GetDiscountValidationRules(validationRule)) },
                { "OFR002", new DiscountCouponCode("OFR002", 1, DiscountCouponType.PERCENT, GetDiscountValidationRules(validationRule)) }
            };
        }

        private IEnumerable<IDiscountValidationRule> GetDiscountValidationRules(int validationRule)
        {
            var rules = new List<IDiscountValidationRule>();
            if (validationRule == 0)
            {
                rules.Add(new GreaterThanValidator(ValidationRuleType.DISTANCE, 10));
                rules.Add(new GreaterThanValidator(ValidationRuleType.WEIGHT, 10));
            };
            if (validationRule == 1)
            {
                rules.Add(new LessThanValidator(ValidationRuleType.DISTANCE, 10));
                rules.Add(new LessThanValidator(ValidationRuleType.WEIGHT, 10));
            };
            if (validationRule == 2)
            {
                rules.Add(new InBetweenValidator(ValidationRuleType.DISTANCE, 10, 20));
                rules.Add(new InBetweenValidator(ValidationRuleType.WEIGHT, 10, 20));
            };
            return rules;
        }
    }
}
