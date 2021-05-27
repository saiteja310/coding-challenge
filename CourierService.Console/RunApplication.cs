using CourierService.Interfaces;
using CourierService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Console
{
    public class RunApplication
    {
        private IDeliveryCostCalculator _deliveryCostCalculator;
        public RunApplication(IDeliveryCostCalculator deliveryCostCalculator)
        {
            _deliveryCostCalculator = deliveryCostCalculator;
        }
        public void Run()
        {
            var input = System.Console.ReadLine().Split(" ");
            var basePrice = Convert.ToDouble(input[0]);
            for (int i = 0; i < Convert.ToInt32(input[1]); i++)
            {
                var (package, discount) = ReadPackage();
                var result = _deliveryCostCalculator
                    .WithBasePrice(basePrice)
                    .ForPackage(package)
                    .WithDiscounts(new List<IDiscount>() { discount })
                    .Calculate();
                System.Console.WriteLine(result);
            }
        }

        private (Package, Discount) ReadPackage()
        {
            var input = System.Console.ReadLine().Split(" ");
            var package = new Package(input[0], Convert.ToDouble(input[1]), Convert.ToDouble(input[2]));
            var discount = new Discount(input[3]);
            return (package, discount);
        }
    }
}
