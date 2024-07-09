using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao
{
    public class AtualizarContratacaoUseCase : IAtualizarContratacaoUseCase
    {
        private readonly IAtualizaContratacaoRepository _atualizaContratacaoRepository;
        private readonly IConsultarContratacaoRepository _consultarContratacaoRepository;

        public AtualizarContratacaoUseCase(IAtualizaContratacaoRepository atualizaContratacaoRepository, IConsultarContratacaoRepository consultarContratacaoRepository)
        {
            _atualizaContratacaoRepository = atualizaContratacaoRepository;
            _consultarContratacaoRepository = consultarContratacaoRepository;
        }

        public async Task AtualizarContratacaoAsync(RealizarContratacaoViewModel contratacao, ConsultarContratacaoCommand command, CancellationToken cancellationToken = default)
        {
            var contratacaoQuery = await ConsultarContratacaoAsync(command);
            // esta logica poderia estar no proprio objeto contratacao
            // contratacao.IncrementarQuantidade(10)
            // duvida
            IncrementarQuantidade(contratacaoQuery, contratacao.Quantidade);
            IncrementarValorUnitario(contratacaoQuery, contratacao.ValorUnitario);

            await _atualizaContratacaoRepository.AtualizarAsync(contratacaoQuery);
        }

        public async Task<Contratacao?> ConsultarContratacaoAsync(ConsultarContratacaoCommand command, CancellationToken cancellationToken = default)
        {
            var contratacoes = await _consultarContratacaoRepository.ConsultarAsync(cancellationToken);
                return contratacoes 
                .Where(x => x.IdContratante == command.IdContratante
            && x.IdProduto == command.IdProduto
            && DateOnly.FromDateTime(x.DataOperacao) == command.DataOperacao)
                .FirstOrDefault();
        }
        private static void IncrementarQuantidade(Contratacao contratacao, int incremento)
            => contratacao.Quantidade += incremento;
        
        private static void IncrementarValorUnitario(Contratacao contratacao, double incremento)
            => contratacao.ValorUnitario += incremento;
    }

    public class ConsultarContratacaoCommandBuilder
    {
        private readonly ConsultarContratacaoCommand _command;

        public ConsultarContratacaoCommandBuilder()
        {
            _command = new ConsultarContratacaoCommand();
        }

        public ConsultarContratacaoCommandBuilder WithIdContratante(int idContratante)
        {
            ArgumentNullException.ThrowIfNull($"nao e possivel atribuir o valor {idContratante}");

            _command.IdContratante = idContratante;

            return this;
        }

        public ConsultarContratacaoCommandBuilder WithIdProduto(int idProduto)
        {
            ArgumentNullException.ThrowIfNull($"nao e possivel atribuir o valor {idProduto}");

            _command.IdProduto = idProduto;

            return this;
        }

        public ConsultarContratacaoCommandBuilder WithDataOperacao(DateOnly dataOperacao)
        {
            ArgumentNullException.ThrowIfNull($"nao e possivel atribuir o valor {dataOperacao}");

            _command.DataOperacao = dataOperacao;

            return this;
        }

        public ConsultarContratacaoCommandBuilder WithDataOperacao(DateTime dataOperacao)
        {
            WithDataOperacao(DateOnly.FromDateTime(dataOperacao));

            return this;
        }

        public ConsultarContratacaoCommand Build()
            => _command;
    }

    public class ConsultarContratacaoCommand
    {
        public int IdContratante { get; set; }
        public int IdProduto  { get; set; }
        public DateOnly DataOperacao  { get; set; }
    }
}
