using CourierService.Implementation.DiscountValidationRules;
using CourierService.Interfaces;
using CourierService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Tests.DiscountValidationRules
{
    [TestFixture]
    class DiscountValidationRulesTests
    {
        [TestCase(ValidationRuleType.DISTANCE, 50, 100, false)]
        [TestCase(ValidationRuleType.DISTANCE, 100.01, 100.01, false)]
        [TestCase(ValidationRuleType.DISTANCE, 150, 100, true)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, false)]
        [TestCase(ValidationRuleType.WEIGHT, 100.01, 100.01, false)]
        [TestCase(ValidationRuleType.WEIGHT, 150, 100, true)]
        public void ValidateGreaterThanRule(ValidationRuleType type, double ruleValue, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = new GreaterThanValidator(type, ruleValue);
            Assert.AreEqual(expected, rule.Validate(package));
        }

        [TestCase(ValidationRuleType.DISTANCE, 50, 100, true)]
        [TestCase(ValidationRuleType.DISTANCE, 100.01, 100.01, false)]
        [TestCase(ValidationRuleType.DISTANCE, 150, 100, false)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, true)]
        [TestCase(ValidationRuleType.WEIGHT, 100.01, 100.01, false)]
        [TestCase(ValidationRuleType.WEIGHT, 150, 100, false)]
        public void ValidateLessThanRule(ValidationRuleType type, double ruleValue, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = new LessThanValidator(type, ruleValue);
            Assert.AreEqual(expected, rule.Validate(package));
        }

        [TestCase(ValidationRuleType.DISTANCE, 50, 100, 75, true)]
        [TestCase(ValidationRuleType.DISTANCE, 50, 100, 50, true)]
        [TestCase(ValidationRuleType.DISTANCE, 50, 100, 100, true)]
        [TestCase(ValidationRuleType.DISTANCE, 50, 100, 100.1, false)]
        [TestCase(ValidationRuleType.DISTANCE, 50, 100, 101, false)]
        [TestCase(ValidationRuleType.DISTANCE, 50, 100, 49.9999999995, false)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, 75, true)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, 50, true)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, 100, true)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, 100.1, false)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, 101, false)]
        [TestCase(ValidationRuleType.WEIGHT, 50, 100, 49.9999999995, false)]
        public void ValidateInBetweenRule(ValidationRuleType type, double ruleLowerBound, double ruleUpperBound, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = new InBetweenValidator(type, ruleLowerBound, ruleUpperBound);
            Assert.AreEqual(expected, rule.Validate(package));
        }

    }
}
