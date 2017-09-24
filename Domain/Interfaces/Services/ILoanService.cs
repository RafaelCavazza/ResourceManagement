using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface ILoanService : IServiceBase<Loan>
    {
        int GetNotLateLoansCount();

        int GetLateLoansCount();
    }
}
