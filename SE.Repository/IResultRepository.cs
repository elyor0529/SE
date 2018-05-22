using SE.Model.Entity;
using SE.Repository.Infrastructure;

namespace SE.Repository
{
    public interface IResultRepository : IGenericRepository<SearchResult>
    {
        SearchResult GetById(long id);
    }
}
