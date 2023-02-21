using World.Api.Data;
using World.Api.Modals;

namespace World.Api.Repository.IRepository
{
    public interface ICountryRepository: IGenericRepository<Country>
    {
        Task Update(Country entity);
    }
}
