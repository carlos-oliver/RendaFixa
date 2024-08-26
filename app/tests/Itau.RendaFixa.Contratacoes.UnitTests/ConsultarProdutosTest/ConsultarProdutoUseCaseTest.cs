using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos.ViewModels;
using Moq;
using System.Net;
using System.Threading;

namespace Itau.RendaFixa.Contratacoes.UnitTests.ConsultarProdutosTest
{
    public class ConsultarProdutoUseCaseTest
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IConsultarProdutoRepository> _mockConsultarProdutoRepository;
        private readonly ConsultarProdutoUseCase _consultarProdutoUseCase;

        public ConsultarProdutoUseCaseTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockConsultarProdutoRepository = new Mock<IConsultarProdutoRepository>();
            _consultarProdutoUseCase = new ConsultarProdutoUseCase(_mockMapper.Object, _mockConsultarProdutoRepository.Object);
        }

        [Fact]
        public async Task ConsultarProduto_ShouldBeOk_WhenSuccessFull()
        {
            //Act
            var nome = "CDB";
            var porPagina = 50;
            var consultarProdutoViewModel = new List<ConsultarProdutoViewModel>
            {
                new ConsultarProdutoViewModel { Id = 1,Nome = nome,Bloqueado = true,IdTipoProduto = 2 }
            };
            var produtos = new List<Produto>
            {
                new Produto{ Id = 1,Nome = nome,Bloqueado = true,IdTipoProduto = 2 }
            };

            _mockConsultarProdutoRepository.Setup(S => S.ConsultarAsync(It.IsAny<CancellationToken>())).ReturnsAsync(produtos);
            _mockMapper.Setup(S => S.Map<IEnumerable<ConsultarProdutoViewModel>>(produtos)).Returns(consultarProdutoViewModel);
            //Arrage
            var (httpStatusCode, produto) = await _consultarProdutoUseCase.ObterProdutoAsync(nome, porPagina, It.IsAny<CancellationToken>());

            //Assert
            Assert.Equal(HttpStatusCode.OK, httpStatusCode);
            Assert.True(produtos.Any());
        }
    }
}
