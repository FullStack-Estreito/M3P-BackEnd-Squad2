namespace Backend.Mapper;

using AutoMapper;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;
using Backend.Output;

public class ResetarSenhaProfile : Profile
{
    public ResetarSenhaProfile()
    {
        CreateMap<ResetarSenhaInput, Usuario>()
        .ForMember(dest => dest.Senha,
        opt => opt.MapFrom(src => src.Senha));

        CreateMap<Usuario, ResetarSenhaOutPut>()
        .ForMember(dest => dest.Senha,
        opt => opt.MapFrom(src => src.Senha));
    }
}