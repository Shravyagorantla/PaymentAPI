using PaymentAPI.Models;
using PaymentAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repositories
{
    public class Payment : IPayment
    {
        private readonly ReturnManagementSystemContext _context;

        public Payment(ReturnManagementSystemContext context)
        {
            _context = context;
        }
        public string PaymentProcess (long CreditCardNumber, int CreditLimit, double ProcessingCharge)
        {
            ProcessDetail processDetail = new ProcessDetail();
            ProcessResponse processResponse = new ProcessResponse();
            ProcessRequest processRequest = new ProcessRequest();
            var p = _context.ProcessDetails.FirstOrDefault(c => c.CreditCardNumber == CreditCardNumber);
            var BalanceAmount = Convert.ToString(CreditLimit - (p.PackagingAndDeliveryCharge + p.ProcessingCharge));
            return BalanceAmount;

        }

    }
}
