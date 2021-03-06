using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBranchRepository : IRepositoryBase<Branch>
    {
        Branch GetByName(string name);
    }
}
