namespace Backend.Mapper;

using AutoMapper;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;
using global::AutoMapper;
using Mapper;

public class UsuarioProfile : Profile
{

    public UsuarioProfile()
    {

        CreateMap<UsuarioInput, Usuario>()
        .ForMember(
            dest => dest.Nome,
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
            // ).ForMember(
            //     dest => dest.Status_Sistema,
            //     opt => opt.MapFrom(src => src.Status_Sistema)
            // ).ForMember(
            //     dest => dest.Endereco_Id,
            //     opt => opt.MapFrom(src => src.Endereco_Id)
            ).ForMember(
                dest => dest.Matricula_Aluno,
                opt => opt.MapFrom(src => src.Matricula_Aluno)
            ).ForMember(
                dest => dest.Telefone,
                opt => opt.MapFrom(src => src.Telefone)
            ).ForMember(
                dest => dest.Empresa_Id,
                opt => opt.MapFrom(src => src.Empresa_Id)
            ).ForMember(
                dest => dest.Codigo_Registro_Professor,
                opt => opt.MapFrom(src => src.Codigo_Registro_Professor)
            );



        CreateMap<Usuario, UsuarioOutput>()
        .ForMember(
            dest => dest.Nome,
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
                dest => dest.Status_Sistema,
                opt => opt.MapFrom(src => src.Status_Sistema)
            ).ForMember(
                dest => dest.Endereco_Id,
                opt => opt.MapFrom(src => src.Endereco_Id)
            ).ForMember(
                dest => dest.Matricula_Aluno,
                opt => opt.MapFrom(src => src.Matricula_Aluno)
            ).ForMember(
                dest => dest.Telefone,
                opt => opt.MapFrom(src => src.Telefone)
            ).ForMember(
                dest => dest.Empresa_Id,
                opt => opt.MapFrom(src => src.Empresa_Id)
            ).ForMember(
                dest => dest.Codigo_Registro_Professor,
                opt => opt.MapFrom(src => src.Codigo_Registro_Professor)
            );

    }
}