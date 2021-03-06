using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IBranchAppService :IAppServiceBase<Branch>
    {
        Branch GetByName(string name);
    }
}
