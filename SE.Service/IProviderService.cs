using SE.Model.Entity;
using SE.Service.Core;

namespace SE.Service
{
    public interface IProviderService : IEntityService<SearchProvider>
    {
        SearchProvider GetById(long id);
    }
}
