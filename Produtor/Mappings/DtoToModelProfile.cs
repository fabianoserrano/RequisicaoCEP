using AutoMapper;
using CoreRequisicaoCEP;
using APIRequisicaoCEP.Dtos;

namespace APIRequisicaoCEP.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<RequisicaoCEP, RequisicaoCepDtoCreate>().ReverseMap();
        }
    }
}
