using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Api_Orcamento.Models;

namespace Api_Orcamento.Service
{
    public class SolicitacaoService
    {
        private readonly IMongoCollection<Models.Solicitacao> _budgetStorageCollection;

        public SolicitacaoService(
            IOptions<BudgetManagerDataBaseSettings> budgetManagerDataBaseSettings)
        {
            var mongoClient = new MongoClient(
                budgetManagerDataBaseSettings.Value.ConnectionStrings);
            var mongoDataBase = mongoClient.GetDatabase(
                budgetManagerDataBaseSettings.Value.DataBaseName);
            _budgetStorageCollection = mongoDataBase.GetCollection<Models.Solicitacao>(
                budgetManagerDataBaseSettings.Value.BudgetCollectionSolicitation);
        }

        public Task<List<Solicitacao>> GetAllAsync() => GetAsync();

        public async Task<List<Models.Solicitacao>> GetAsync() =>
            await _budgetStorageCollection.Find(_ => true).ToListAsync();
        public async Task<Models.Solicitacao?> GetAsync(string id) =>
            await _budgetStorageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Models.Solicitacao newDocumentStorage) =>
            await _budgetStorageCollection.InsertOneAsync(newDocumentStorage);
        public async Task UpdateAsync(string id, Models.Solicitacao updateDocumentStorage) =>
           await _budgetStorageCollection.ReplaceOneAsync(x => x.Id == id, updateDocumentStorage);

        public async Task DeleteAsync(string id) =>
            await _budgetStorageCollection.DeleteOneAsync(x => x.Id == id);
        //Adição da funcionalidade pequisar
        public async Task<List<Solicitacao>> SearchAsync(string searchTerm)
        {
            // Se o termo de pesquisa for nulo ou vazio, retorne todos os fornecedores
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAsync();
            }

            // Converte o termo de pesquisa para minúsculas uma única vez para comparações
            var lowerSearchTerm = searchTerm.ToLower();

            // Constrói o filtro para a pesquisa no MongoDB

            var filter = Builders<Solicitacao>.Filter.Where(f =>

                f.Nome.ToLower().Contains(lowerSearchTerm) ||

                f.Preco.ToLower().Contains(lowerSearchTerm) ||

                f.Descricao.Contains(searchTerm)
            );

            // Executa a busca no MongoDB com o filtro e retorna a lista
            return await _budgetStorageCollection.Find(filter).ToListAsync();

        }

    }
}
