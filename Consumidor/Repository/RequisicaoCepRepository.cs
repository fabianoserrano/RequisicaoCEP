using ServiceRequisicaoCEP.Entities;
using ServiceRequisicaoCEP.Interfaces;
using ServiceRequisicaoCEP.Context;

namespace ServiceRequisicaoCEP.Repository
{
    public class RequisicaoCepRepository : BaseRepository<RequisicaoCepEntity>, IRequisicaoCepRepository
    {
        public RequisicaoCepRepository(RequisicaoCEPContext context) : base(context)
        {
        }
    }
}
