using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Exceptions
{
    public class InvalidPriceException : ArgumentException
    {
        public InvalidPriceException()
            : this("Invalid Price given. Please revalidate.")
        {
        }

        public InvalidPriceException(string message) : base(message)
        {
        }
    }
}
