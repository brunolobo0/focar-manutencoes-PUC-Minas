using MongoDB.Driver;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api_Orcamento.Service;
using Api_Orcamento.Models;
using Microsoft.Extensions.Options;


namespace Orcamento_test.Service
{
    public class FornecedorServiceTest
    {
        private readonly Mock<IMongoCollection<Fornecedor>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly Mock<IMongoClient> _mockClient;
        private readonly FornecedorService _fornecedorService;

        public FornecedorServiceTest()
        {
            // Arrange: Configurar mocks
            _mockCollection = new Mock<IMongoCollection<Fornecedor>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            var mockSettings = new Mock<IOptions<BudgetManagerDataBaseSettings>>();
            mockSettings.Setup(s => s.Value).Returns(new BudgetManagerDataBaseSettings
            {
                ConnectionStrings = "mongodb://localhost:27017",
                DataBaseName = "BudgetManager",
                BudgetCollectionSupplier = "Fornecedor"
            });

            _mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                       .Returns(_mockDatabase.Object);

            _mockDatabase.Setup(d => d.GetCollection<Fornecedor>(It.IsAny<string>(), null))
                         .Returns(_mockCollection.Object);

            _fornecedorService = new FornecedorService(mockSettings.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnListOfFornecedor()
        {
            // Arrange
            var mockFornecedor = new List<Fornecedor> { new Fornecedor { Id = "67a7c3cc55f499fe1cfff4de", NomeFantasia = "Nome fantasia" } };
            var asyncCursor = new Mock<IAsyncCursor<Fornecedor>>();
            asyncCursor.Setup(_ => _.Current).Returns(mockFornecedor);
            asyncCursor.SetupSequence(_ => _.MoveNext(It.IsAny<System.Threading.CancellationToken>())).Returns(true).Returns(false);

            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Fornecedor>>(),
                                                   It.IsAny<FindOptions<Fornecedor>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(asyncCursor.Object);

            // Act
            var result = await _fornecedorService.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Nome fantasia", result[0].NomeFantasia);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            var invalidId = "000000000000000000000000"; // Um ObjectId válido que não existe na coleção
            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Fornecedor>>(),
                                                   It.IsAny<FindOptions<Fornecedor>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(Mock.Of<IAsyncCursor<Fornecedor>>());

            // Act
            var result = await _fornecedorService.GetAsync(invalidId);

            // Assert
            Assert.Null(result);
        }
    }
}