using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Interfaces
{
    public interface IDeliveryCostCalculator : ICostCalculator
    {
        Package Package { get; }

        IEnumerable<IDiscountCalculator> Discounts { get; }

        IDeliveryCostCalculator ForPackage(Package package);

        IDeliveryCostCalculator WithBasePrice(decimal basePrice);

        IDeliveryCostCalculator WithDiscounts(IEnumerable<IDiscountCalculator> discounts);

    }
}
