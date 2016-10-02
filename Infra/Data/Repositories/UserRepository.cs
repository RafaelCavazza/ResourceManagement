using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

    }
}
