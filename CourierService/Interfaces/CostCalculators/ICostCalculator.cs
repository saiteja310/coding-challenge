using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Interfaces
{
    public interface ICostCalculator
    {
        double BasePrice { get; }

        double Calculate();
    }
}
