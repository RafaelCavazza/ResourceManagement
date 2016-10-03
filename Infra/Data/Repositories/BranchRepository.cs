using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Data.Repositories
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
    }
}
