using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class BranchService : ServiceBase<Branch>, IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository) : base(branchRepository)
        {
            _branchRepository = branchRepository;
        }
    }
}
