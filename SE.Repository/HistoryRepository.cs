using System.Data.Entity;
using System.Linq;
using SE.Model.Entity;
using SE.Repository.Infrastructure;

namespace SE.Repository
{
    public class HistoryRepository : GenericRepository<ResultHistory>, IHistoryRepository
    {
        public HistoryRepository(DbContext context)
              : base(context)
        {

        }

        public ResultHistory GetById(long id)
        {
            return FindBy(f => f.Id == id).FirstOrDefault();
        }
    }
}
