using SE.Model.Entity;
using SE.Repository;
using SE.Repository.Infrastructure;
using SE.Service.Core;

namespace SE.Service
{
    public class ProviderService : EntityService<SearchProvider>, IProviderService
    {
        private readonly IProviderRepository _repository;

        public ProviderService(IUnitOfWork unitOfWork, IProviderRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public SearchProvider GetById(long id)
        {
            return _repository.GetById(id);
        }
    }
}
