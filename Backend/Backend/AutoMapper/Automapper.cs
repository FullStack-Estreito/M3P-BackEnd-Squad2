using System;
using AutoMapper;
using Backend.DTO.Atendimentos;
using Backend.DTO.Avaliacao;
using Backend.DTO.Exercicio;
using Backend.Models;

namespace Backend.AutoMapper
{
	public class Automapper : Profile
    {
		public Automapper()
		{
            // Atendimentos
            CreateMap<Atendimento, AtendimentosReadDTO>();
            CreateMap<AtendimentosCreateDTO, Atendimento>();
            CreateMap<AtendimentosUpdateDTO, Atendimento>();

            // Avaliacao
            CreateMap<Avaliacao, AvaliacaoReadDTO>();

            CreateMap<AvaliacaoCreateDTO, Avaliacao>();

            CreateMap<AvaliacaoUpdateDTO, Avaliacao>();

            // Exercicio
            CreateMap<Exercicio, ExercicioReadDTO>()
                .ForMember(destino => destino.Aluno_Nome, origem => origem.MapFrom(src => src.Aluno))
                .ForMember(destino => destino.Professor_Nome, origem => origem.MapFrom(src => src.Professor));;

            CreateMap<Usuario, ExercicioAlunoReadDTO>();

            CreateMap<Usuario, ExercicioProfessorReadDTO>();

            CreateMap<ExercicioCreateDTO, Exercicio>();

            CreateMap<ExercicioUpdateDTO, Exercicio>();

        }
    }
}

