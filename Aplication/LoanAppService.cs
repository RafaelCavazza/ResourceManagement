using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Aplication 
{
    public class LoanAppService  : AppServiceBase<Loan>, ILoanAppService
    {
        public readonly ILoanService _loanService;

        public LoanAppService(ILoanService loanService) : base(loanService)
        {
            _loanService = loanService;
        }

        public int GetLateLoansCount()
        {
            return _loanService.GetLateLoansCount();
        }

        public int GetNotLateLoansCount()
        {
            return _loanService.GetNotLateLoansCount();
        }
    }
}
