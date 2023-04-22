using AutoMapper;
using Domain.Models;
using Servico.DTOs;

namespace Api
{
    public class AdapterDtoDomain
    {
        public static MapperConfiguration MapperRegister()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompromissoDto, CompromissoDominio>(MemberList.None)
                    .ForMember(dom => dom.IdUsuario, y => y.MapFrom(dto => dto.IdUsuario))
                    .ForMember(dom => dom.Data, y => y.MapFrom(dto => dto.Data))
                    .ForMember(dom => dom.Texto, y => y.MapFrom(dto => dto.Texto))
                    .ForMember(dom => dom.Id, opt => opt.Ignore())
                    .ForMember(dom => dom.DataInclusao, opt => opt.Ignore())
                    .ReverseMap();

                cfg.CreateMap<CompromissoAlteradoDto, CompromissoDominio>(MemberList.None)
                    .ForMember(dto => dto.IdUsuario, y => y.MapFrom(dto => dto.IdUsuario))
                    .ForMember(dto => dto.Data, y => y.MapFrom(dto => dto.Data))
                    .ForMember(dto => dto.Texto, y => y.MapFrom(dto => dto.Texto))
                    .ForMember(dto => dto.Id, y => y.MapFrom(dto => dto.Id))
                    .ForMember(dom => dom.DataInclusao, opt => opt.Ignore())
                    .ReverseMap();

            });
        }
    }
}
