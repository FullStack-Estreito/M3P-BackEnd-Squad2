namespace Backend.Mapper;

using AutoMapper;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;
using global::AutoMapper;
using Mapper;

public class UsuarioCompletoProfile : Profile
{

    public UsuarioCompletoProfile()
    {

        CreateMap<UsuarioCompletoInput, UsuarioCompleto>()
        .ForMember(dest => dest.Nome,
            opt => opt.MapFrom(src => src.Nome)
            ).ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            ).ForMember(
                dest => dest.CPF,
                opt => opt.MapFrom(src => src.CPF)
            ).ForMember(
                dest => dest.Tipo,
                opt => opt.MapFrom(src => src.Tipo)
            ).ForMember(
                dest => dest.Genero,
                opt => opt.MapFrom(src => src.Genero)
            ).ForMember(
                dest => dest.Senha,
                opt => opt.MapFrom(src => src.Senha)
                     ).ForMember(
                dest => dest.Matricula_Aluno,
                opt => opt.MapFrom(src => src.Matricula_Aluno)
            ).ForMember(
                dest => dest.Telefone,
                opt => opt.MapFrom(src => src.Telefone)
            ).ForMember(
                dest => dest.Codigo_Registro_Professor,
                opt => opt.MapFrom(src => src.Codigo_Registro_Professor)
            ).ForMember(dest => dest.CEP,
    opt => opt.MapFrom(src => src.CEP))
    .ForMember(dest => dest.Logradouro,
    opt => opt.MapFrom(src => src.Logradouro))
    .ForMember(dest => dest.Localidade,
    opt => opt.MapFrom(src => src.Localidade))
    .ForMember(dest => dest.Bairro,
    opt => opt.MapFrom(src => src.Bairro))
    .ForMember(dest => dest.UF,
    opt => opt.MapFrom(src => src.UF))
    .ForMember(dest => dest.Numero,
    opt => opt.MapFrom(src => src.Numero))
    .ForMember(dest => dest.Complemento,
    opt => opt.MapFrom(src => src.Complemento));


    }
}