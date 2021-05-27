using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Interfaces
{
    public interface ICouponCodeValidator
    {
        bool ValidateCouponCode(Package package, DiscountCouponCode couponCode);
        DiscountCouponCode GetCouponCode(IDiscount discount);
    }
}
