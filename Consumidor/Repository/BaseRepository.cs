using Microsoft.EntityFrameworkCore;
using ServiceRequisicaoCEP.Context;
using ServiceRequisicaoCEP.Entities;
using ServiceRequisicaoCEP.Interfaces;

namespace ServiceRequisicaoCEP.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly RequisicaoCEPContext _context;

        public BaseRepository(RequisicaoCEPContext context)
        {
            _context = context;
        }

        public T Insert(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();

                item.CreateAt = DateTime.UtcNow;

                _context.Set<T>().Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu uma exceção ao inserir: " + ex.Message);
                throw;
            }

            return item;
        }
    }
}
