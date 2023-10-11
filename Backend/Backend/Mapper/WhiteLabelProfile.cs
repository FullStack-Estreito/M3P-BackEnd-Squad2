using AutoMapper;
using Backend.DTO.WhiteLabel;
using Backend.Models;

namespace Backend.AutoMapper
{
	public class WhiteLabelProfile : Profile
    {
		public WhiteLabelProfile()
		{
            //Entrada
			CreateMap<WhiteLabelDTO, Empresa>();
            //Saida
			CreateMap<Empresa, WhiteLabelDTO>();
        }
    }
}