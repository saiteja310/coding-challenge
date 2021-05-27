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
    class ValidationRuleFactoryTests
    {
        private DistanceValidationRulesFactory _distanceValidationRulesFactory;
        private WeightValidationRulesFactory _weightValidationRulesFactory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _distanceValidationRulesFactory = new DistanceValidationRulesFactory();
            _weightValidationRulesFactory = new WeightValidationRulesFactory();
        }


        [TestCase(50, 100, false)]
        [TestCase(100.01, 100.01, false)]
        [TestCase(150, 100, true)]
        public void CreateDistanceGreaterValidationRule(double ruleValue, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = _distanceValidationRulesFactory.CreateGreaterThanDistanceRule(ruleValue);
            Assert.AreEqual(expected, rule.Validate(package));
        }

        [TestCase(50, 100, false)]
        [TestCase(100.01, 100.01, false)]
        [TestCase(150, 100, true)]
        public void CreateWeightGreaterValidationRule(double ruleValue, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = _weightValidationRulesFactory.CreateGreaterThanWeightRule(ruleValue);
            Assert.AreEqual(expected, rule.Validate(package));
        }

        [TestCase(50, 100, true)]
        [TestCase(100.01, 100.01, false)]
        [TestCase(150, 100, false)]
        public void CreateDistanceLesserValidationRule(double ruleValue, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = _distanceValidationRulesFactory.CreateLessThanDistanceRule(ruleValue);
            Assert.AreEqual(expected, rule.Validate(package));
        }

        [TestCase(50, 100, true)]
        [TestCase(100.01, 100.01, false)]
        [TestCase(150, 100, false)]
        public void CreateWeightLesserValidationRule(double ruleValue, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = _weightValidationRulesFactory.CreateLessThanWeightRule(ruleValue);
            Assert.AreEqual(expected, rule.Validate(package));
        }

        [TestCase(50, 100, 75, true)]
        [TestCase(50, 100, 50, true)]
        [TestCase(50, 100, 100, true)]
        [TestCase(50, 100, 100.1, false)]
        [TestCase(50, 100, 101, false)]
        [TestCase(50, 100, 49.9999999995, false)]
        public void CreateDistanceLesserValidationRule(double ruleLowerBound, double ruleUpperBound, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = _distanceValidationRulesFactory.CreateInBetweenDistanceRule(ruleLowerBound, ruleUpperBound);
            Assert.AreEqual(expected, rule.Validate(package));
        }

        [TestCase(50, 100, 75, true)]
        [TestCase(50, 100, 50, true)]
        [TestCase(50, 100, 100, true)]
        [TestCase(50, 100, 100.1, false)]
        [TestCase(50, 100, 101, false)]
        [TestCase(50, 100, 49.9999999995, false)]
        public void CreateWeightLesserValidationRule(double ruleLowerBound, double ruleUpperBound, double packageValue, bool expected)
        {
            Package package = new Package("UnitTestPackage", packageValue, packageValue);
            IDiscountValidationRule rule = _weightValidationRulesFactory.CreateInBetweenWeightRule(ruleLowerBound, ruleUpperBound);
            Assert.AreEqual(expected, rule.Validate(package));
        }

    }
}
