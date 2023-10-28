using System;
using AutoMapper;
using Backend.DTO.Atendimentos;
using Backend.DTO.Avaliacao;
using Backend.DTO.Exercicio;
using Backend.DTO.Login;
using Backend.DTO.Empresa;
using Backend.Models;
using Backend.DTO.Usuario;
using Backend.DTO.Log;

namespace Backend.AutoMapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            // Atendimentos
            CreateMap<Atendimento, AtendimentosReadDTO>()
                .ForMember(destino => destino.Aluno_nome, origem => origem.MapFrom(src => src.Aluno))
                .ForMember(destino => destino.Pedagogo_nome, origem => origem.MapFrom(src => src.Pedagogo));

            CreateMap<Usuario, AtendimentoAlunoReadDTO>();
            CreateMap<Usuario, AtendimentoPedagogoReadDTO>();
            CreateMap<AtendimentosCreateDTO, Atendimento>();
            CreateMap<AtendimentosUpdateDTO, Atendimento>();

            // Avaliacao
            CreateMap<Avaliacao, AvaliacaoReadDTO>()
                 .ForMember(destino => destino.Aluno_nome, origem => origem.MapFrom(src => src.Aluno))
                .ForMember(destino => destino.Professor_nome, origem => origem.MapFrom(src => src.Professor));

            CreateMap<Usuario, AvaliacaoAlunoReadDTO>();
            CreateMap<Usuario, AvaliacaoProfessorReadDTO>();
            CreateMap<AvaliacaoCreateDTO, Avaliacao>();
            CreateMap<AvaliacaoUpdateDTO, Avaliacao>();

            // Empresa
            CreateMap<Empresa, EmpresaReadDTO>();
            CreateMap<EmpresaCreateDTO, Empresa>();
            CreateMap<EmpresaUpdateDTO, Empresa>();

            // Exercicio
            CreateMap<Exercicio, ExercicioReadDTO>()
                .ForMember(destino => destino.Aluno_nome, origem => origem.MapFrom(src => src.Aluno))
                .ForMember(destino => destino.Professor_nome, origem => origem.MapFrom(src => src.Professor));

            CreateMap<Usuario, ExercicioAlunoReadDTO>();
            CreateMap<Usuario, ExercicioProfessorReadDTO>();
            CreateMap<ExercicioCreateDTO, Exercicio>();
            CreateMap<ExercicioUpdateDTO, Exercicio>();

            // Login
            CreateMap<LoginCreateDTO, Login>();

            // Log
            CreateMap<Log, LogReadDTO>();
            CreateMap<LogCreateDTO, Log>();

            // Usuário 
            CreateMap<Usuario, UsuarioReadDTO>();
            CreateMap<UsuarioCreateDTO, Usuario>();
            CreateMap<UsuarioUpdateDTO, Usuario>();
        }
    }
}

