using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Aplication
{
    public class BranchAppService  : AppServiceBase<Branch>, IBranchAppService
    {
        public readonly IBranchService _branchService;

        public BranchAppService(IBranchService branchService) : base(branchService)
        {
            _branchService = branchService;
        }

        public Branch GetByName(string name)
        {
            return _branchService.GetByName(name);
        }
    }
}
