using AutoMapper;
using Dominio.Models;
using Servico.DTOs.Compromisso;

namespace Api
{
    public class AdapterDtoDomain
    {
        public static MapperConfiguration MapperRegister()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompromissoInsercaoDto, CompromissoDominio>(MemberList.None)
                    .ForMember(dom => dom.Data, y => y.MapFrom(dto => dto.Data))
                    .ForMember(dom => dom.Texto, y => y.MapFrom(dto => dto.Texto))
                    .ForMember(dom => dom.Id, opt => opt.Ignore())
                    .ForMember(dom => dom.DataInclusao, opt => opt.Ignore())
                    .ReverseMap();

                cfg.CreateMap<CompromissoAlteracaoDto, CompromissoDominio>(MemberList.None)
                    .ForMember(dto => dto.Data, y => y.MapFrom(dto => dto.Data))
                    .ForMember(dto => dto.Texto, y => y.MapFrom(dto => dto.Texto))
                    .ForMember(dto => dto.Id, y => y.MapFrom(dto => dto.Id))
                    .ForMember(dom => dom.DataInclusao, opt => opt.Ignore())
                    .ReverseMap();

                cfg.CreateMap<CompromissoVisualizacaoDto, CompromissoDominio>(MemberList.None)
                   .ForMember(dto => dto.Data, y => y.MapFrom(dto => dto.Data))
                   .ForMember(dto => dto.Texto, y => y.MapFrom(dto => dto.Texto))
                   .ForMember(dto => dto.Id, y => y.MapFrom(dto => dto.Id))
                   .ForMember(dom => dom.DataInclusao, opt => opt.Ignore())
                   .ReverseMap();

            });
        }
    }
}
