using MassTransit;
using CoreRequisicaoCEP;
using AutoMapper;
using ServiceRequisicaoCEP.Entities;
using ServiceRequisicaoCEP.Interfaces;

namespace ServiceRequisicaoCEP.Eventos
{
    public class RequisicaoCEPConsumidor : IConsumer<RequisicaoCEP>
    {
        private IRequisicaoCepRepository _repository;
        private readonly IMapper _mapper;

        public RequisicaoCEPConsumidor(IRequisicaoCepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Consume(ConsumeContext<RequisicaoCEP> context)
        {
            RequisicaoCepEntity entity = _mapper.Map<RequisicaoCepEntity>(context.Message);
            _repository.Insert(entity);

            return Task.CompletedTask;
        }
    }
}
