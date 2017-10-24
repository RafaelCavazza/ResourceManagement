using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ILoanRepository : IRepositoryBase<Loan>
    {
        int GetNotLateLoansCount();

        int GetLateLoansCount();
    }
}
