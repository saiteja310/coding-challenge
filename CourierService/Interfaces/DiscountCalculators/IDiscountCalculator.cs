using CourierService.Models;

namespace CourierService.Interfaces
{
    public interface IDiscountCalculator
    {
        double CalculateDiscount(double price, double couponValue);
    }
}