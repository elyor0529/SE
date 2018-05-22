using SE.Model.Entity;
using SE.Repository;
using SE.Repository.Infrastructure;
using SE.Service.Core;

namespace SE.Service
{
    public class ResultService : EntityService<SearchResult>, IResultService
    {
        private readonly IResultRepository _repository;

        public ResultService(IUnitOfWork unitOfWork, IResultRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public SearchResult GetById(long id)
        {
            return _repository.GetById(id);
        }
    }
}
