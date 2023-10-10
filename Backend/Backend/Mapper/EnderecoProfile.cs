namespace Backend.Mapper;

using AutoMapper;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;
using Backend.Output;
using global::AutoMapper;

public class EnderecoProfile : Profile
{

    public EnderecoProfile()
    {

        CreateMap<EnderecoInput, Endereco>()
        .ForMember(dest => dest.CEP,
        opt => opt.MapFrom(src => src.CEP))
        .ForMember(dest => dest.Logradouro,
        opt => opt.MapFrom(src => src.Logradouro))
        .ForMember(dest => dest.Bairro,
        opt => opt.MapFrom(src => src.Bairro))
        .ForMember(dest => dest.Bairro,
        opt => opt.MapFrom(src => src.Bairro))
        .ForMember(dest => dest.Estado,
        opt => opt.MapFrom(src => src.Estado))
        .ForMember(dest => dest.Numero,
        opt => opt.MapFrom(src => src.Numero))
        .ForMember(dest => dest.Complemento,
        opt => opt.MapFrom(src => src.Complemento))
        .ForMember(dest => dest.Ponto_Referencia,
        opt => opt.MapFrom(src => src.Ponto_Referencia));
    
      CreateMap<Endereco, EnderecoOutPut>()
        .ForMember(dest => dest.Id,
        opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.CEP,
        opt => opt.MapFrom(src => src.CEP))
        .ForMember(dest => dest.Logradouro,
        opt => opt.MapFrom(src => src.Logradouro))
        .ForMember(dest => dest.Bairro,
        opt => opt.MapFrom(src => src.Bairro))
        .ForMember(dest => dest.Bairro,
        opt => opt.MapFrom(src => src.Bairro))
        .ForMember(dest => dest.Estado,
        opt => opt.MapFrom(src => src.Estado))
        .ForMember(dest => dest.Numero,
        opt => opt.MapFrom(src => src.Numero))
        .ForMember(dest => dest.Complemento,
        opt => opt.MapFrom(src => src.Complemento))
        .ForMember(dest => dest.Ponto_Referencia,
        opt => opt.MapFrom(src => src.Ponto_Referencia));
    
    }

}