using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.Extensions.Options;
using Moq;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api_Orcamento.Tests
{
    public class ProdutoServiceTest
    {
        private readonly Mock<IMongoCollection<Produto>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly Mock<IMongoClient> _mockClient;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTest()
        {
            // Arrange: Configurar mocks
            _mockCollection = new Mock<IMongoCollection<Produto>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            var mockSettings = new Mock<IOptions<BudgetManagerDataBaseSettings>>();
            mockSettings.Setup(s => s.Value).Returns(new BudgetManagerDataBaseSettings
            {
                ConnectionStrings = "mongodb://localhost:27017",
                DataBaseName = "BudgetManager",
                BudgetCollectionProduct = "Produto"
            });

            _mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                       .Returns(_mockDatabase.Object);

            _mockDatabase.Setup(d => d.GetCollection<Produto>(It.IsAny<string>(), null))
                         .Returns(_mockCollection.Object);

            _produtoService = new ProdutoService(mockSettings.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnListOfProdutos()
        {
            // Arrange
            var mockProdutos = new List<Produto> { new Produto { Id = "67a7c43c55f499fe1cfff4ed", NomeProduto = "Produto 1" } };
            var asyncCursor = new Mock<IAsyncCursor<Produto>>();
            asyncCursor.Setup(_ => _.Current).Returns(mockProdutos);
            asyncCursor.SetupSequence(_ => _.MoveNext(It.IsAny<System.Threading.CancellationToken>())).Returns(true).Returns(false);

            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Produto>>(),
                                                   It.IsAny<FindOptions<Produto>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(asyncCursor.Object);

            // Act
            var result = await _produtoService.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Produto 1", result[0].NomeProduto);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            var invalidId = "000000000000000000000000"; // Um ObjectId válido que não existe na coleção
            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Produto>>(),
                                                   It.IsAny<FindOptions<Produto>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(Mock.Of<IAsyncCursor<Produto>>());

            // Act
            var result = await _produtoService.GetAsync(invalidId);

            // Assert
            Assert.Null(result);
        }
    }
}
