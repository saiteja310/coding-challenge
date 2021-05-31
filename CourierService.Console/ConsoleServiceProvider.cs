using CourierService.Implementation.CostCalculators;
using CourierService.Implementation.CouponCodeGenerator;
using CourierService.Implementation.CouponCodeService;
using CourierService.Implementation.DiscountCalculators;
using CourierService.Implementation.DiscountValidationRules;
using CourierService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Console
{
    class ConsoleServiceProvider : IDisposable
    {
        public ServiceProvider ServiceProvider { get; }
        public ConsoleServiceProvider()
        {
            var services = new ServiceCollection();
            RegisterServices(services);
            ServiceProvider = services.BuildServiceProvider(true);
        }

        private void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDeliveryCostCalculator, InitialOfferDeliveryCostCalculator>();

            serviceCollection.AddSingleton<IDiscountCouponCodeGenerator, StaticDiscountCouponCodeGenerator>();

            serviceCollection.AddSingleton<ICouponCodeService, CouponCodeService>(); 

            serviceCollection.AddSingleton<IDiscountCalculator, FixedAmountDiscountCalculator>();
            serviceCollection.AddSingleton<IDiscountCalculator, PercentDiscountCalculator>();
            serviceCollection.AddSingleton<DiscountCalculatorFactory>();

            serviceCollection.AddSingleton<DistanceValidationRulesFactory>();
            serviceCollection.AddSingleton<WeightValidationRulesFactory>();

            serviceCollection.AddSingleton<RunApplication>();
        }

        public void Dispose()
        {
            if (ServiceProvider == null)
            {
                return;
            }
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
