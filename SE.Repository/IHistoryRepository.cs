using SE.Model.Entity;
using SE.Repository.Infrastructure;

namespace SE.Repository
{
    public interface IHistoryRepository : IGenericRepository<ResultHistory>
    {
        ResultHistory GetById(long id);
    }
}
