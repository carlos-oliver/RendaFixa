using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos.ViewModels;
using Moq;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.UnitTests.ObterTipoProdutoUseCaseTest
{
    public class ObterTipoProdutoUseCaseTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IConsultarTipoProdutoRepository> _mockConsultarTipoProdutoRepository;
        private readonly ObterTipoProdutoUseCase _obterTipoProdutoUseCase;

        public ObterTipoProdutoUseCaseTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockConsultarTipoProdutoRepository = new Mock<IConsultarTipoProdutoRepository>();
            _obterTipoProdutoUseCase = new ObterTipoProdutoUseCase(_mockConsultarTipoProdutoRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task ObterTipoProduto_ShouldBeOk_WhenSucessFull()
        {
            //act
            var tipoProdutos = new List<TipoProduto> 
            { 
                new TipoProduto
                {
                    Id = 1,
                    Nome = "CDB"
                }
            };

            var tipoProdutoViewModel = new List<TipoProdutoViewModel>
            {
                new TipoProdutoViewModel
                {
                    Id = 1,
                    Nome = "CDB"
                }
            };

            _mockConsultarTipoProdutoRepository.Setup(m => m.ConsultarAsync(It.IsAny<CancellationToken>())).ReturnsAsync(tipoProdutos);
            _mockMapper.Setup(m => m.Map<IEnumerable<TipoProdutoViewModel>>(tipoProdutos)).Returns(tipoProdutoViewModel);

            //arrange
            var (httpStatusCode, result) = await _obterTipoProdutoUseCase.ExecuteAsync(It.IsAny<CancellationToken>());
            //assert
            Assert.Equal(HttpStatusCode.OK, httpStatusCode);

        }

        [Fact]
        public async Task ObterTipoProduto_ShouldBeNotFound_WhenResultNull()
        {
            //act
            _mockConsultarTipoProdutoRepository.Setup(m => m.ConsultarAsync(It.IsAny<CancellationToken>()))
                                               .ReturnsAsync((IEnumerable<TipoProduto>?)null);

            //arrange
            var (httpStatusCode, result) = await _obterTipoProdutoUseCase.ExecuteAsync(It.IsAny<CancellationToken>());
            //assert
            Assert.Equal(HttpStatusCode.NotFound, httpStatusCode);
            Assert.Contains(result.Erros, e => e.Code == "001" && e.Message == "Tipo produto não encontrado");

        }

    }
}
