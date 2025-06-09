using Api_Orcamento.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Orcamento.Service
{
    public class OrcamentoService
    {
        private readonly IMongoCollection<Orcamento> _budgetsCollection;

        public OrcamentoService(IOptions<BudgetManagerDataBaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionStrings);
            var database = client.GetDatabase(settings.Value.DataBaseName);
            _budgetsCollection = database.GetCollection<Orcamento>(settings.Value.BudgetCollectionBudget);
        }

      
        public Task<List<Orcamento>> GetAllAsync() => GetAsync();

        public async Task<List<Orcamento>> GetAsync() =>
            await _budgetsCollection.Find(_ => true).ToListAsync();

        public async Task<Orcamento?> GetAsync(string id) =>
            await _budgetsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Orcamento newBudget) =>
            await _budgetsCollection.InsertOneAsync(newBudget);

        public async Task UpdateAsync(string id, Orcamento updateBudget) =>
            await _budgetsCollection.ReplaceOneAsync(x => x.Id == id, updateBudget);

        public async Task DeleteAsync(string id) =>
            await _budgetsCollection.DeleteOneAsync(x => x.Id == id);

        //Adição da funcionalidade pequisar
        public async Task<List<Orcamento>> SearchAsync(string searchTerm)
        {
            // Se o termo de pesquisa for nulo ou vazio, retorne todos os fornecedores
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAsync();
            }

            // Converte o termo de pesquisa para minúsculas uma única vez para comparações
            var lowerSearchTerm = searchTerm.ToLower();

            // Constrói o filtro para a pesquisa no MongoDB

            var filter = Builders<Orcamento>.Filter.Where(f =>

                f.Nome.ToLower().Contains(lowerSearchTerm) ||

                f.Email.ToLower().Contains(lowerSearchTerm) ||

                f.Telefone.ToLower().Contains(lowerSearchTerm) ||

                f.Detalhes.Contains(searchTerm)
            );

            // Executa a busca no MongoDB com o filtro e retorna a lista
            return await _budgetsCollection.Find(filter).ToListAsync();


        }
    }
}
