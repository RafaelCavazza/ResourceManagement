using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class LoanService : ServiceBase<Loan>, ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository) : base(loanRepository)
        {
            _loanRepository = loanRepository;
        }
    }
}
