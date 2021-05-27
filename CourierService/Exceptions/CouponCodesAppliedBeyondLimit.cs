using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Exceptions
{
    public class CouponCodesAppliedBeyondLimit : ArgumentException
    {
        public CouponCodesAppliedBeyondLimit(int currentValue, int maxApplicable)
            : this($"Maximum Coupons Applicable are {maxApplicable} although {currentValue} have been applied.")
        {

        }

        public CouponCodesAppliedBeyondLimit(string message) : base(message)
        {

        }
    }
}
