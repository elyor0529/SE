using System.Data.Entity;
using System.Linq;
using SE.Model.Entity;
using SE.Repository.Infrastructure;

namespace SE.Repository
{
    public class ResultRepository : GenericRepository<SearchResult>, IResultRepository
    {
        public ResultRepository(DbContext context)
              : base(context)
        {

        }

        public SearchResult GetById(long id)
        {
            return FindBy(f => f.Id == id).FirstOrDefault();
        }
    }
}
