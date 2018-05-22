using SE.Model.Entity;
using SE.Repository.Infrastructure;

namespace SE.Repository
{
    public interface IProviderRepository : IGenericRepository<SearchProvider>
    {
        SearchProvider GetById(long id);
    }
}
