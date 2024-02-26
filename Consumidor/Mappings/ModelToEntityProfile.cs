using AutoMapper;
using ServiceRequisicaoCEP.Entities;
using CoreRequisicaoCEP;

namespace ServiceRequisicaoCEP.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<RequisicaoCEP, RequisicaoCepEntity>().ReverseMap();
        }
    }
}
