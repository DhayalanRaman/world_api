using World.Api.Data;
using World.Api.Modals;

namespace World.Api.Repository.IRepository
{
    public interface ICoutryRepository
    {
        Task<List<Country>>GetAll();
        Task<Country> GetCountryById(int id);

        Task Create(Country country);
        Task Update(Country country);
        Task Delete(Country country);
        Task Save();
        bool IsCountryExist(string name);
    }
}
