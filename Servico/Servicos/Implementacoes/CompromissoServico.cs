﻿using AutoMapper;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Models;
using Dominio.Retorno;
using Servico.DTOs;

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

        public async Task<bool> AlterarCompromisso(CompromissoAlteracaoDto compromisso)
        {

            try
            {
                var retorno = await _compromissoRepositorio.AlterarCompromisso(_mapper.Map<CompromissoDominio>(compromisso));
                return retorno;
            }
            catch (Exception ex)
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


        public async Task<CompromissoDto> ObterCompromisso(int idCompromisso)
        {
            try
            {
                var retorno = _mapper.Map<CompromissoDto>(await _compromissoRepositorio.BuscarCompromisso(idCompromisso));
                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return null;
            };
        }


        public async Task<bool> DeletarCompromisso(int idCompromisso)
        {
            try
            {
                var retorno = await _compromissoRepositorio.ExcluirCompromisso(idCompromisso);

                if (!retorno) _mensagens.AdicionarAviso("O compromisso não existe no sistema");

                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return false;
            };
        }


        public async Task<int?> InserirCompromisso(CompromissoDto compromisso)
        {
            try
            {
                var retorno = await _compromissoRepositorio.InserirCompromisso(_mapper.Map<CompromissoDominio>(compromisso));

                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return null;
            };
        }

    }
}
