using CourierService.Interfaces;
using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService
{
    public abstract class DeliveryCostCalculator : IDeliveryCostCalculator
    {
        public decimal BasePrice { get; private set; }
        public Package Package { get; private set; }
        public IEnumerable<IDiscount> Discounts { get; private set; }

        public abstract decimal Calculate();

        public virtual IDeliveryCostCalculator ForPackage(Package package)
        {
            this.Package = package;
            return this;
        }

        public virtual IDeliveryCostCalculator WithBasePrice(decimal basePrice)
        {
            this.BasePrice = basePrice;
            return this;
        }

        public virtual IDeliveryCostCalculator WithDiscounts(IEnumerable<IDiscount> discounts)
        {
            this.Discounts = discounts;
            return this;
        }

    }
}