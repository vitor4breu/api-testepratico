using AutoMapper;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Models;
using Dominio.Retorno;
using Servico.DTOs.Compromisso;

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
                if (!retorno) _mensagens.AdicionarAviso("O compromisso especificado não existe");
                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return false;
            };
        }

        public async Task<IEnumerable<CompromissoVisualizacaoDto>> BuscarCompromissos()
        {
            try
            {
                var retorno = _mapper.Map<IEnumerable<CompromissoVisualizacaoDto>>(await _compromissoRepositorio.BuscarCompromissos());
                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return null;
            };
        }


        public async Task<CompromissoVisualizacaoDto> ObterCompromisso(int idCompromisso)
        {
            try
            {
                var retorno = _mapper.Map<CompromissoVisualizacaoDto>(await _compromissoRepositorio.BuscarCompromisso(idCompromisso));
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
                if (!retorno) _mensagens.AdicionarAviso("O compromisso especificado não existe");
                return retorno;
            }
            catch (Exception ex)
            {
                _mensagens.AdicionarErro(ex.Message);
                return false;
            };
        }


        public async Task<int?> InserirCompromisso(CompromissoInsercaoDto compromisso)
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
