using World.Api.Modals;

namespace World.Api.Repository.IRepository
{
    public interface IStateRepository : IGenericRepository<States>
    {
        Task Update(States entity);
    }
}
