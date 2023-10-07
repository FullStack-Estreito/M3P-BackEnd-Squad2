namespace Backend.Mapper;

using AutoMapper;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;
using Backend.Output;

public class EmpresaProfile : Profile
{

    public EmpresaProfile()
    {
        CreateMap<EmpresaInput, Empresa>()
        .ForMember(dest => dest.Nome_Empresa,
        opt => opt.MapFrom(src => src.Nome_Empresa)
        ).ForMember(
                dest => dest.Slogan,
                opt => opt.MapFrom(src => src.Slogan)
        ).ForMember(
                dest => dest.Paleta_Cores,
                opt => opt.MapFrom(src => src.Paleta_Cores)
                ).ForMember(
                dest => dest.Logotipo_URL,
                opt => opt.MapFrom(src => src.Logotipo_URL)
                ).ForMember(
                dest => dest.Demais_Infos,
                opt => opt.MapFrom(src => src.Demais_Infos)
            );

        CreateMap<Empresa, EmpresaOutPut>()
    .ForMember(dest => dest.Nome_Empresa,
    opt => opt.MapFrom(src => src.Nome_Empresa)
    ).ForMember(
            dest => dest.Slogan,
            opt => opt.MapFrom(src => src.Slogan)
    ).ForMember(
            dest => dest.Paleta_Cores,
            opt => opt.MapFrom(src => src.Paleta_Cores)
            ).ForMember(
            dest => dest.Logotipo_URL,
            opt => opt.MapFrom(src => src.Logotipo_URL)
            ).ForMember(
            dest => dest.Demais_Infos,
            opt => opt.MapFrom(src => src.Demais_Infos));
        //     ).ForMember(
        //     dest => dest.Usuario_Id,
        //      opt => opt.MapFrom(src => src.Usuarios)
        //     );

    }
}