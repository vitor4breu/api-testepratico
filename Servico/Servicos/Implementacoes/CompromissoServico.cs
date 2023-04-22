using AutoMapper;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Domain.Models;
using Domain.Retorno;
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
        private readonly MensagemRetorno _mensagens;

        public CompromissoServico(ICompromissoRepositorio compromissoRepositorio, IMapper mapper, MensagemRetorno mensagens)
        {
            _compromissoRepositorio = compromissoRepositorio;
            _mapper = mapper;
            _mensagens = mensagens;
        }

        public async Task<bool> AlterarCompromisso(CompromissoAlteradoDto compromisso) { 

            try
            {
                var retorno = await _compromissoRepositorio.AlterarCompromisso(_mapper.Map<CompromissoDominio>(compromisso));
                return retorno;
            } catch( Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return false;
            };
        }

        public async Task<IEnumerable<CompromissoDto>> BuscarCompromissos()
        {
            try
            {
                var retorno = _mapper.Map<IEnumerable<CompromissoDto>>(await _compromissoRepositorio.BuscarCompromissos());
                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return null;
            };
        }
           

        public async Task<IEnumerable<CompromissoDto>> BuscarCompromissosPorUsuario(int idUsuario)
        {
            try
            {
                var retorno = _mapper.Map<IEnumerable<CompromissoDto>>(await _compromissoRepositorio.BuscarCompromissosPorUsuario(idUsuario));
                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return null ;
            };
        }
            

        public async Task<bool> DeletarCompromisso(int idCompromisso)
        {
            try
            {
                var retorno = await _compromissoRepositorio.ExcluirCompromisso(idCompromisso);

                if(!retorno) _mensagens.AdicionarAviso("O compromisso não existe no sistema");

                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return false;
            };
        }
        

        public async Task<bool> InserirCompromisso(CompromissoDto compromisso)
        {
            try
            {
                var retorno = await _compromissoRepositorio.InserirCompromisso(_mapper.Map<CompromissoDominio>(compromisso));

                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return false;
            };
        }
        
    }
}
