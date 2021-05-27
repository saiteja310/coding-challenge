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
        bool IsLoggingEnabled { get; }

        Package Package { get; }

        IEnumerable<IDiscount> Discounts { get; }

        IDeliveryCostCalculator ForPackage(Package package);

        IDeliveryCostCalculator WithBasePrice(double basePrice);

        IDeliveryCostCalculator WithDiscounts(IEnumerable<IDiscount> discounts);

        IDeliveryCostCalculator WithLogging();
    }
}
