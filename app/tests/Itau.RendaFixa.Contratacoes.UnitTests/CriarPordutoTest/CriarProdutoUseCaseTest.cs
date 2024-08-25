using AutoMapper;
using Itau.RendaFixa.Contratacoes.Bussiness.Contracts.Repositories;
using Itau.RendaFixa.Contratacoes.Bussiness.Models;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarProduto.ViewModels;
using Moq;
using System.Net;

namespace Itau.RendaFixa.Contratacoes.UnitTests.CriarPordutoTest
{
    public class CriarProdutoUseCaseTest
    {
        private readonly Mock<ICriarProdutoRepository> _mockcriarProdutoRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CriarProdutoUseCase _criarProdutoUseCase;

        public CriarProdutoUseCaseTest()
        {
            _mockcriarProdutoRepository = new Mock<ICriarProdutoRepository>();
            _mockMapper = new Mock<IMapper>();
            _criarProdutoUseCase = new CriarProdutoUseCase(_mockcriarProdutoRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CriarProduto_ShouldReturnCreated_WhenSucessful()
        {
            // Arrange
            var criarProdutoViewModel = new CriarProdutoViewModel();
            var produto = new Produto
            {
                Bloqueado = true,
                IdTipoProduto = 3,
                Nome = "teste",
                Id = 10
            };

            _mockMapper.Setup(m => m.Map<Produto>(criarProdutoViewModel)).Returns(produto);
            _mockcriarProdutoRepository.Setup(m => m.Criar(produto, It.IsAny<CancellationToken>())).ReturnsAsync(produto);
            //Act
            var (statusCode, result) = await _criarProdutoUseCase.CriarProduto(criarProdutoViewModel);
            //Assert
            Assert.Equal(HttpStatusCode.Created, statusCode);
            Assert.NotNull(result.Data);
            Assert.Equal(produto, result.Data);
        }

        [Fact]
        public async Task CriarProduto_ShouldReturnInternalServerError_WhenException()
        {
            //Arrange
            var criarProdutoViewModel = new CriarProdutoViewModel();
            var produto = new Produto
            {
                Bloqueado = true,
                IdTipoProduto = 3,
                Nome = "teste",
                Id = 10
            };

            _mockMapper.Setup(m => m.Map<Produto>(criarProdutoViewModel)).Returns(produto);
            _mockcriarProdutoRepository
                .Setup(m => m.Criar(produto, It.IsAny<CancellationToken>())).ThrowsAsync(new Exception());
            //Act
            var (statusCode, result) = await _criarProdutoUseCase.CriarProduto(criarProdutoViewModel);

            //Assert
            Assert.Equal(HttpStatusCode.InternalServerError, statusCode);
            Assert.NotNull(result.Erros);
        }
    }
}