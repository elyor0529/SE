using System.Collections.Generic;
using SE.Model;

namespace SE.Service.Core
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {

        void Create(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAll();      

        void Update(T entity);

    }
}
