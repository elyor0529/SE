using SE.Model.Entity;
using SE.Service.Core;

namespace SE.Service
{
    public interface IResultService : IEntityService<SearchResult>
    {
        SearchResult GetById(long id);
    }
}
