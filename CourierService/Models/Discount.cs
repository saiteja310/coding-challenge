using CourierService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Models
{
    public class Discount : IDiscount
    {
        public string CouponCode { get; }
        public Discount(string couponCode)
        {
            CouponCode = couponCode;
        }
    }
}
