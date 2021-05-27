using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Exceptions
{
    public class InvalidCouponPercentageException : ArgumentException
    {
        public InvalidCouponPercentageException()
            : this("Invalid Coupon Percentage given. Please revalidate.")
        {
        }

        public InvalidCouponPercentageException(string message) : base(message)
        {
        }
    }
}
