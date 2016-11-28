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
    }
}
