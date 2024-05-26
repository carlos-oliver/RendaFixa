using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.DbContexts;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao.ViewModel;

namespace Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao
{
    public class AtualizarContratacaoUseCase : IAtualizarContratacaoUseCase
    {
        private readonly IContratacaoDbContext _context;
        private readonly IAtualizaContratacaoRepository _atualizaContratacaoRepository;

        public AtualizarContratacaoUseCase(IContratacaoDbContext context, IAtualizaContratacaoRepository atualizaContratacaoRepository)
        {
            _context = context;
            _atualizaContratacaoRepository = atualizaContratacaoRepository;
        }
 
        public async Task AtualizarContratacao(RealizarContratacaoViewModel contratacao, ConsultarContratacaoCommand command, CancellationToken cancellationToken = default)
        {
            //var contratacaoQuery = await Consultarcontratacao(contratacao.IdContratante, contratacao.IdProduto, DateOnly.FromDateTime(contratacao.DataOperacao), cancellationToken);
            var contratacaoQuery = await ConsultarContratacaoAsync(command);
            // esta logica poderia estar no proprio objeto contratacao
            // contratacao.IncrementarQuantidade(10)
            contratacaoQuery.Quantidade += contratacao.Quantidade;
            contratacaoQuery.ValorUnitario += contratacao.ValorUnitario;

            await _atualizaContratacaoRepository.AtualizaContratacaoAsync(contratacaoQuery);
            // SaveChangesAsync retorna o numero de linhas afetadas, voce poderia logar isso para facilitar analise de problemas
            //await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Contratacao?> ConsultarContratacaoAsync(ConsultarContratacaoCommand command, CancellationToken cancellationToken = default)
            => _context.Contratacoes.Where(x => x.IdContratante == command.IdContratante
                    && x.IdProduto == command.IdProduto
                    && DateOnly.FromDateTime(x.DataOperacao) == command.DataOperacao)
                .FirstOrDefault();
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
