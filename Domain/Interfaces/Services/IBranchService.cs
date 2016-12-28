using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IBranchService : IServiceBase<Branch>
    {
        Branch GetByName(string name);
    }
}
