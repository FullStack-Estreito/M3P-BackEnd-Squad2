using System;
using AutoMapper;
using Backend.DTO.Avaliacao;
using Backend.Models;

namespace Backend.AutoMapper
{
	public class Automapper : Profile
    {
		public Automapper()
		{
			CreateMap<Avaliacao, AvaliacaoReadDTO>();

        }
	}
}

