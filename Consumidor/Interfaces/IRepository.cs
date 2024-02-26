using ServiceRequisicaoCEP.Entities;

namespace ServiceRequisicaoCEP.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Insert(T item);
    }
}
