using SE.Model.Entity;
using SE.Service.Core;

namespace SE.Service
{
    public interface IHistoryService : IEntityService<ResultHistory>
    {
        ResultHistory GetById(long id);
    }
}
