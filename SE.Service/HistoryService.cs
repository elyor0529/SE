using SE.Model.Entity;
using SE.Repository;
using SE.Repository.Infrastructure;
using SE.Service.Core;

namespace SE.Service
{
    public class HistoryService : EntityService<ResultHistory>, IHistoryService
    {
        private readonly IHistoryRepository _repository;

        public HistoryService(IUnitOfWork unitOfWork, IHistoryRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public ResultHistory GetById(long id)
        {
            return _repository.GetById(id);
        }
    }
}
