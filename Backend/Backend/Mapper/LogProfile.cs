namespace Backend.Mapper;

using AutoMapper;
using Backend.DtoEntrada;
using Backend.DtoSaida;
using Backend.Models;
using Backend.Output;
using global::AutoMapper;

public class LogProfile : Profile
{

    public LogProfile()
    {

        CreateMap<LogInput, Log>()
         .ForMember(dest => dest.Usuario_Id,
         opt => opt.MapFrom(src => src.Usuario_Id))
         .ForMember(dest => dest.Data,
         opt => opt.MapFrom(src => src.Data))
         .ForMember(dest => dest.Detalhes,
         opt => opt.MapFrom(src => src.Detalhes))
         .ForMember(dest => dest.Acao,
         opt => opt.MapFrom(src => src.Acao));

        CreateMap<Log, LogOutPut>()
     .ForMember(dest => dest.Id,
     opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Usuario_Id,
      opt => opt.MapFrom(src => src.Usuario_Id))
      .ForMember(dest => dest.Data,
      opt => opt.MapFrom(src => src.Data))
      .ForMember(dest => dest.Detalhes,
      opt => opt.MapFrom(src => src.Detalhes))
      .ForMember(dest => dest.Acao,
      opt => opt.MapFrom(src => src.Acao));

    }
}