using CourierService.Interfaces;
using CourierService.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models
{
    public class DiscountCouponCode : IEquatable<DiscountCouponCode>
    {
        public string Code { get; }
        public decimal Value { get; }
        public DiscountCouponType DiscountCouponType { get; }
        public IEnumerable<IDiscountValidationRule> DiscountValidationRules { get; }

        public DiscountCouponCode(string code, decimal value, DiscountCouponType discountCouponType, IEnumerable<IDiscountValidationRule> rules)
        {
            Code = code;
            Value = value;
            DiscountCouponType = discountCouponType;
            DiscountValidationRules = rules;
        }

        public bool Equals(DiscountCouponCode other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || this.Code.Equals(other.Code);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DiscountCouponCode);
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }
    }
}
