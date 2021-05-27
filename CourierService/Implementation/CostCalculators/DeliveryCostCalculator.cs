using CourierService.Exceptions;
using CourierService.Interfaces;
using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Implementation.CostCalculators
{
    public abstract class DeliveryCostCalculator : IDeliveryCostCalculator
    {
        public double BasePrice { get; private set; }
        public bool IsLoggingEnabled { get; private set; }
        public Package Package { get; private set; }
        public IEnumerable<IDiscount> Discounts { get; private set; }

        public abstract double Calculate();

        public virtual IDeliveryCostCalculator ForPackage(Package package)
        {
            this.Package = package;
            return this;
        }

        public virtual IDeliveryCostCalculator WithBasePrice(double basePrice)
        {
            if (basePrice < 0)
            {
                throw new InvalidPriceException(basePrice);
            }
            this.BasePrice = basePrice;
            return this;
        }

        public virtual IDeliveryCostCalculator WithDiscounts(IEnumerable<IDiscount> discounts)
        {
            this.Discounts = discounts;
            return this;
        }

        public IDeliveryCostCalculator WithLogging()
        {
            this.IsLoggingEnabled = true;
            return this;
        }
    }
}
