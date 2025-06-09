using Api_Orcamento.Models;
using Api_Orcamento.Service;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento_test.Service
{
    public class OrcamentoServiceTest
    {
        private readonly Mock<IMongoCollection<Orcamento>> _mockCollection;
        private readonly Mock<IMongoDatabase> _mockDatabase;
        private readonly Mock<IMongoClient> _mockClient;
        private readonly OrcamentoService _orcamentoService;

        public OrcamentoServiceTest()
        {
            // Arrange: Configurar mocks
            _mockCollection = new Mock<IMongoCollection<Orcamento>>();
            _mockDatabase = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();

            var mockSettings = new Mock<IOptions<BudgetManagerDataBaseSettings>>();
            mockSettings.Setup(s => s.Value).Returns(new BudgetManagerDataBaseSettings
            {
                ConnectionStrings = "mongodb://localhost:27017",
                DataBaseName = "BudgetManager",
                BudgetCollectionBudget = "Orcamento"
            });

            _mockClient.Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                       .Returns(_mockDatabase.Object);

            _mockDatabase.Setup(d => d.GetCollection<Orcamento>(It.IsAny<string>(), null))
                         .Returns(_mockCollection.Object);

            _orcamentoService = new OrcamentoService(mockSettings.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnListOfOrcamento()
        {
            // Arrange
            var mockOrcamento = new List<Orcamento> { new Orcamento { Id = "67a7c3cc55f499fe1cfff4de", Nome = "Nome do Cliente" } };
            var asyncCursor = new Mock<IAsyncCursor<Orcamento>>();
            asyncCursor.Setup(_ => _.Current).Returns(mockOrcamento);
            asyncCursor.SetupSequence(_ => _.MoveNext(It.IsAny<System.Threading.CancellationToken>())).Returns(true).Returns(false);

            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Orcamento>>(),
                                                   It.IsAny<FindOptions<Orcamento>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(asyncCursor.Object);

            // Act
            var result = await _orcamentoService.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Nome do Cliente", result[0].Nome);
        }

        [Fact]
        public async Task GetAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            var invalidId = "000000000000000000000000"; // Um ObjectId válido que não existe na coleção
            _mockCollection.Setup(c => c.FindAsync(It.IsAny<FilterDefinition<Orcamento>>(),
                                                   It.IsAny<FindOptions<Orcamento>>(),
                                                   It.IsAny<System.Threading.CancellationToken>()))
                           .ReturnsAsync(Mock.Of<IAsyncCursor<Orcamento>>());

            // Act
            var result = await _orcamentoService.GetAsync(invalidId);

            // Assert
            Assert.Null(result);
        }
    }
}
