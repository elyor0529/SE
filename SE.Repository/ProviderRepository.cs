using System.Data.Entity;
using System.Linq;
using SE.Model.Entity;
using SE.Repository.Infrastructure;

namespace SE.Repository
{
    public class ProviderRepository : GenericRepository<SearchProvider>, IProviderRepository
    {

        public ProviderRepository(DbContext context)
              : base(context)
        {

        }

        public SearchProvider GetById(long id)
        {
            return FindBy(f => f.Id == id).FirstOrDefault();
        }

    }
}
