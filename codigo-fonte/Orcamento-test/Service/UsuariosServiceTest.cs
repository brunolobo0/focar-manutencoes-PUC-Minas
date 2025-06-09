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
    public class UsuariosServiceTest
    {
        private readonly Mock<IMongoCollection<Usuarios>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly Mock<IMongoClient> _mockClient;
        private readonly AutenticacaoService _usuariosService;

        public UsuariosServiceTest()
        {
            // Arrange: Configurar mocks
            _mockCollection = new Mock<IMongoCollection<Usuarios>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            var mockSettings = new Mock<IOptions<BudgetManagerDataBaseSettings>>();
            mockSettings.Setup(s => s.Value).Returns(new BudgetManagerDataBaseSettings
            {
                ConnectionStrings = "mongodb://localhost:27017",
                DataBaseName = "BudgetManager",
                BudgetCollectionUsers = "Usuarios"
            });

            _mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                       .Returns(_mockDatabase.Object);

            _mockDatabase.Setup(d => d.GetCollection<Usuarios>(It.IsAny<string>(), null))
                         .Returns(_mockCollection.Object);

            _usuariosService = new AutenticacaoService(mockSettings.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnListOfUsuarios()
        {
            // Arrange
            var mockUsuarios = new List<Usuarios> { new Usuarios { Id = "67a7c43c55f499fe1cfff4ed", Nome = "Matheus Oliveira Rosario" } };
            var asyncCursor = new Mock<IAsyncCursor<Usuarios>>();
            asyncCursor.Setup(_ => _.Current).Returns(mockUsuarios);
            asyncCursor.SetupSequence(_ => _.MoveNext(It.IsAny<System.Threading.CancellationToken>())).Returns(true).Returns(false);

            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Usuarios>>(),
                                                   It.IsAny<FindOptions<Usuarios>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(asyncCursor.Object);

            // Act
            var result = await _usuariosService.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Matheus Oliveira Rosario", result[0].Nome);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            var invalidId = "000000000000000000000000"; // Um ObjectId válido que não existe na coleção
            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Usuarios>>(),
                                                   It.IsAny<FindOptions<Usuarios>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(Mock.Of<IAsyncCursor<Usuarios>>());

            // Act
            var result = await _usuariosService.GetAsync(invalidId);

            // Assert
            Assert.Null(result);
        }
    }
}