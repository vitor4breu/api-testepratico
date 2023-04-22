using AutoMapper;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Domain.Models;
using Servico.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementacoes
{
    public class CompromissoServico : ICompromissoServico
    {
        private readonly ICompromissoRepositorio _compromissoRepositorio;
        private readonly IMapper _mapper;

        public CompromissoServico(ICompromissoRepositorio compromissoRepositorio, IMapper mapper)
        {
            _compromissoRepositorio = compromissoRepositorio;
            _mapper = mapper;
        }

        public Task<bool> AlterarCompromisso(CompromissoAlteradoDto compromisso) =>
            _compromissoRepositorio.AlterarCompromisso(_mapper.Map<CompromissoDominio>(compromisso));

        public async Task<IEnumerable<CompromissoDto>> BuscarCompromissos() =>
            _mapper.Map<IEnumerable<CompromissoDto>>(await _compromissoRepositorio.BuscarCompromissos());

        public async Task<IEnumerable<CompromissoDto>> BuscarCompromissosPorUsuario(int idUsuario) =>
            _mapper.Map<IEnumerable<CompromissoDto>>(await _compromissoRepositorio.BuscarCompromissosPorUsuario(idUsuario));

        public async Task<bool> DeletarCompromisso(int idCompromisso) =>
            await _compromissoRepositorio.ExcluirCompromisso(idCompromisso);

        public async Task<bool> InserirCompromisso(CompromissoDto compromisso) =>
            await _compromissoRepositorio.InserirCompromisso(_mapper.Map<CompromissoDominio>(compromisso));
        
    }
}
