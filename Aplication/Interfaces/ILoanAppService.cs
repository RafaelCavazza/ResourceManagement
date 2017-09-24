using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface ILoanAppService : IAppServiceBase<Loan>
    {
        int GetNotLateLoansCount();

        int GetLateLoansCount();
    }
}