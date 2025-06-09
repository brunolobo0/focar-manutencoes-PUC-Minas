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
    public class ClienteServiceTest
    {
        private readonly Mock<IMongoCollection<Cliente>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly Mock<IMongoClient> _mockClient;
        private readonly ClienteService _clienteService;

        public ClienteServiceTest()
        {
            // Arrange: Configurar mocks
            _mockCollection = new Mock<IMongoCollection<Cliente>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            var mockSettings = new Mock<IOptions<BudgetManagerDataBaseSettings>>();
            mockSettings.Setup(s => s.Value).Returns(new BudgetManagerDataBaseSettings
            {
                ConnectionStrings = "mongodb://localhost:27017",
                DataBaseName = "BudgetManager",
                BudgetCollectionCustomer = "Cliente"
            });

            _mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                       .Returns(_mockDatabase.Object);

            _mockDatabase.Setup(d => d.GetCollection<Cliente>(It.IsAny<string>(), null))
                         .Returns(_mockCollection.Object);

            _clienteService = new ClienteService(mockSettings.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnListOfClientes()
        {
            // Arrange
            var mockClientes = new List<Cliente> { new Cliente { Id = "67a7c43c55f499fe1cfff4ed", Nome = "Nome do Cliente" } };
            var asyncCursor = new Mock<IAsyncCursor<Cliente>>();
            asyncCursor.Setup(_ => _.Current).Returns(mockClientes);
            asyncCursor.SetupSequence(_ => _.MoveNext(It.IsAny<System.Threading.CancellationToken>())).Returns(true).Returns(false);

            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Cliente>>(),
                                                   It.IsAny<FindOptions<Cliente>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(asyncCursor.Object);

            // Act
            var result = await _clienteService.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Nome do Cliente", result[0].Nome);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            var invalidId = "000000000000000000000000"; // Um ObjectId válido que não existe na coleção
            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Cliente>>(),
                                                   It.IsAny<FindOptions<Cliente>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(Mock.Of<IAsyncCursor<Cliente>>());

            // Act
            var result = await _clienteService.GetAsync(invalidId);

            // Assert
            Assert.Null(result);
        }
    }
}