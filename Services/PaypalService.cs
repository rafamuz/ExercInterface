using ExercInterface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercInterface.Services
{
    internal class PaypalService : IPaymentService
    {
        public double Interest(double amount, int months)
        {
            return amount * 0.01 * months;
        }

        public double PaymentFee(double amount)
        {
            return amount * 0.02;
        }
    }
}
