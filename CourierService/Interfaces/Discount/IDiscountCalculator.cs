using CourierService.Models;
using CourierService.Models.Enum;

namespace CourierService.Interfaces
{
    public interface IDiscountCalculator
    {
        DiscountCouponType DiscountCouponType { get; }
        double CalculateDiscount(double price, double couponValue);
    }
}