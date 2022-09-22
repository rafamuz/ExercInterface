using ExercInterface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercInterface.Services
{
    internal class ContractService
    {        
        private IPaymentService _paymentService;

        public ContractService(IPaymentService paymentService) //Injeção de dependência na hora da instanciação.
        {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {                
                //Calculates the final value of quota, considering the business rules.
                double updatedQuota = basicQuota + _paymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _paymentService.PaymentFee(updatedQuota);

                //Add i months to the date, in order to be shown 
                //properly on the return for the program screen.
                DateTime date = contract.Date.AddMonths(i);

                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
